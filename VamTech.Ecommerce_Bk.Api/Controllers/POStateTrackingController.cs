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
    public class POStateTrackingController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IMailService _mailService;

        public POStateTrackingController(IOrderService orderService, IMapper mapper, IUriService uriService, IMailService mailService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _uriService = uriService;
            _mailService = mailService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStates(IEnumerable<POStateTrackingDto> states)
        {
            var result = await _orderService.UpdateStates(states);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}