using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VamTech.Ecommerce.Api.Interfaces;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.Interfaces;
using VamTech.Ecommerce.Infraestructure.Interfaces;
using VamTech.Ecommerce.Infraestructure.Services;
using VamTech.Ecommerce.Infraestructure.Resources;
using VamTech.Ecommerce.Core.Enumerations;

namespace VamTech.Ecommerce.Api.Services
{
    

    public class UserService : IUserService
    {

        private UserManager<IdentityUser> _userManger;
        private IConfiguration _configuration;
        private IMailService _mailService;
        private IClientService _clientService;
        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration, IMailService mailService, IClientService clientService) 
        {
            _userManger = userManager;
            _configuration = configuration;
            _mailService = mailService;
            _clientService = clientService;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if (model == null)
                throw new NullReferenceException("El formulario de registro esta vacio");

            if (model.Password != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    Message = "El password de confirmacion no coincide con el password" ,
                    IsSuccess = false,
                };

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
            };

           
            var result = await _userManger.CreateAsync(identityUser, model.Password);

            await _userManger.AddClaimAsync(identityUser, new Claim(_configuration["ClaimTypeProfile"].ToString(), "CLIENTE"));

            if(result.Succeeded)
            {
                var confirmEmailToken = await _userManger.GenerateEmailConfirmationTokenAsync(identityUser);

                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                string url = $"{_configuration["AppUrl"]}/api/auth/confirmemail?userid={identityUser.Id}&token={validEmailToken}";

                
                string[] recipients = { identityUser.Email };
                 _mailService.ConfirmPassword(url, recipients);

                //crear cliente
                try
                {
                    await _clientService.CreateClient(new Core.DTOs.ClientDto { Email = model.Email, FirstName = model.FirstName, Document = model.Document, MobilePhone = model.MobilePhone, HomePhone = model.HomePhone, LastName = model.LastName });
                }
                catch (Exception)
                {

                    return new UserManagerResponse
                    {
                        Message = "El cliente no fue creado",
                        IsSuccess = false,
                        Errors = result.Errors.Select(e => e.Description)
                    };
                }


                return new UserManagerResponse
                {
                    Message = "El usuario fue creado correctamente!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "El usuario no fue creado",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManger.FindByEmailAsync(model.Email);
            Client client;

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "No existe el usuario con esa direccion de mail",
                    IsSuccess = false,
                };
            }

            var result = await _userManger.CheckPasswordAsync(user, model.Password);

            if(!result)
                return new UserManagerResponse
                {
                    Message = "Password invalido",
                    IsSuccess = false,
                };
            try
            {
               client = _clientService.GetClientByEmail(model.Email);

            }
            catch (Exception)
            {
                return new UserManagerResponse
                {
                    Message = "No existe el cliente",
                    IsSuccess = false,
                };
            }

            var usr = _userManger.FindByEmailAsync(model.Email);

            string profile = string.Empty;

            foreach (var cla in await _userManger.GetClaimsAsync(usr.Result))
            {
                if(cla.Type == _configuration["ClaimTypeProfile"].ToString())
                    profile = cla.Value;

            }

            var claims = new List<Claim>
            {
                new Claim("Email", model.Email),
                //new Claim("FirstName", client.FirstName),
                //new Claim("LastName", client.LastName),
                //new Claim("MobilePhone", client.MobilePhone),
                //new Claim("HomePhone", client.HomePhone ?? ""),
                new Claim("Document", client.Document.ToString() ?? ""),
                new Claim(_configuration["ClaimTypeProfile"].ToString(), profile),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                ClientId = client.Id,
                Message = "",
                Token = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
                UserName = model.Email,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Document = client.Document.ToString() ?? "",
                Profile = profile
            };
        }

        public async Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManger.FindByIdAsync(userId);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "El usuario no fue creado"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManger.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Email confirmado correctamente!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                IsSuccess = false,
                Message = "Email no confirmado",
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> ForgetPasswordAsync(string email)
        {
            var user = await _userManger.FindByEmailAsync(email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No existe el usuario asociado con el email",
                };

            var token = await _userManger.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={email}&token={validToken}";

            
            string[] recipients = { email};
            await _mailService.ResetPassword(url, recipients);


            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "El link para resetear password ha sido enviado al mail exitosamente!"
            };
        }

        public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var user = await _userManger.FindByEmailAsync(model.Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "El usuario no esta asociado con el mail",
                };

            if(model.NewPassword != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "El password no coincide con el de confirmacion",
                };

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManger.ResetPasswordAsync(user, normalToken, model.NewPassword);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "El password ha sido reseteado correctamente!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Algo salio mal",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }
    }
}
