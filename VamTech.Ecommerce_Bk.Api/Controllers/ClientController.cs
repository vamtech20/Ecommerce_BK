using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VamTech.Ecommerce.Api.Responses;
using VamTech.Ecommerce.Core.CustomEntities;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.Interfaces;
using VamTech.Ecommerce.Core.QueryFilters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace VamTech.Ecommerce.Api.Controllers
{
   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ClientController(IClientService clientService, IMapper mapper, IUriService uriService)
        {
            _clientService = clientService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all Clients
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetClients))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ClientDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetClients([FromQuery]ClientQueryFilter filters)
        {
            var metadata = new Metadata();

            var clients = _clientService.GetClients(filters, Url.RouteUrl(nameof(GetClients)), out metadata);

            var response = new ApiResponse<IEnumerable<ClientDto>>(clients)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);

            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var Client = await _clientService.GetClient(id);
            var ClientDto = _mapper.Map<ClientDto>(Client);
            var response = new ApiResponse<ClientDto>(ClientDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Client(ClientDto ClientDto)
        {
            var Client = _mapper.Map<Client>(ClientDto);

            await _clientService.InsertClient(Client);

            ClientDto = _mapper.Map<ClientDto>(Client);
            var response = new ApiResponse<ClientDto>(ClientDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ClientDto ClientDto)
        {
            var Client = _mapper.Map<Client>(ClientDto);
            Client.Id = id;

            var result = await _clientService.UpdateClient(Client);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clientService.DeleteClient(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}