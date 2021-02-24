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
    public class OfferTypeController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public OfferTypeController(IOfferService offerService, IMapper mapper, IUriService uriService)
        {
            _offerService = offerService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all Offer Types
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetOfferTypes))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OfferTypeDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetOfferTypes()
        {
            var offerTypes = _offerService.GetOfferTypes();

            var response = new ApiResponse<IEnumerable<OfferTypeDto>>(offerTypes)
            {
               
            };

           
            return Ok(response);
        }

       
    }
}