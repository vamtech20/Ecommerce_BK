using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using VamTech.Ecommerce.Infraestructure.Resources;
using VamTech.Ecommerce.Infraestructure.Interfaces;

namespace VamTech.Ecommerce.Infraestructure.Services
{
    public class MailService : IMailService
    {
        private IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
           
            _configuration = configuration;
           
        }
        public Task<bool> SendMail(string subject, string content, string[] recipients)
        {
           
            if (recipients == null || recipients.Length == 0)
                throw new ArgumentException("recipients");
            try
            {
                //var client = new System.Net.Mail.SmtpClient
                //{
                //    Host = _configuration["Mail:Server"],
                //    Port = int.Parse(_configuration["Mail:OutgoingPortSMTP"]),
                //    EnableSsl = true,
                //    UseDefaultCredentials = false,
                //    Credentials = new System.Net.NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"])
                //};

                //using (var msg = new System.Net.Mail.MailMessage(_configuration["Mail:From"], recipients[0], subject, content))
                //{
                //    for (int i = 1; i < recipients.Length; i++)
                //        msg.To.Add(recipients[i]);

                //        client.Send(msg);
                //        return new Task<bool>(() => true);


                //}
                using (MailMessage emailMessage = new MailMessage())
                {
                    emailMessage.From = new MailAddress(_configuration["Mail:From"]);
                    for (int i = 0; i < recipients.Length; i++)
                        emailMessage.To.Add(new MailAddress(recipients[i]));
                                        
                    emailMessage.Subject = subject;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Body = content;
                    emailMessage.Priority = MailPriority.Normal;
                    using (SmtpClient MailClient = new SmtpClient(_configuration["Mail:Server"], int.Parse(_configuration["Mail:OutgoingPortSMTP"])))
                    {
                        MailClient.EnableSsl = true;
                        MailClient.Credentials = new System.Net.NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
                        MailClient.Send(emailMessage);
                        return new Task<bool>(() => true);
                    }
                }

            }
            catch (Exception ex)
            {

                return new Task<bool>(() => false);
            }
        }

        public Task<bool> ConfirmPassword(string url, string[] recipients)
        {
            return SendMail(Messages.Confirm_your_email_subject , string.Format(Messages.Confirm_your_email_body, _configuration["Company"], url ), recipients);
        }

        public Task<bool> NewLogin(string[] recipients)
        {
            return SendMail(Messages.New_login_subject, string.Format(Messages.New_login_Body, DateTime.Now), recipients);
        }

        public Task<bool> ResetPassword(string url, string[] recipients)
        {
            return SendMail(Messages.Reset_Password_subject, string.Format(Messages.Reset_Password_body, _configuration["Company"], url), recipients);
        }

        
    }
}
