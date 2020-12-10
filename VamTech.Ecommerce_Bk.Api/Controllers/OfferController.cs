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
using VamTech.Ecommerce.Infraestructure.Interfaces;
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
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public OfferController(IOfferService OfferService, IMapper mapper, IUriService uriService)
        {
            _offerService = OfferService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all Offers
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetOffers))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OfferDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetOffers([FromQuery]OfferQueryFilter filters)
        {
            var metadata = new Metadata();

            var offs = _offerService.GetOffers(filters, Url.RouteUrl(nameof(GetOffers)), out metadata);

            var response = new ApiResponse<IEnumerable<OfferDto>>(offs)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);

            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffer(int id)
        {
            var Offer = await _offerService.GetOffer(id);
            var OfferDto = _mapper.Map<OfferDto>(Offer);
            var response = new ApiResponse<OfferDto>(OfferDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Offer(OfferDto OfferDto)
        {
            var Offer = _mapper.Map<Offer>(OfferDto);

            await _offerService.InsertOffer(Offer);

            OfferDto = _mapper.Map<OfferDto>(Offer);
            var response = new ApiResponse<OfferDto>(OfferDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, OfferDto OfferDto)
        {
            var Offer = _mapper.Map<Offer>(OfferDto);
            Offer.Id = id;

            var result = await _offerService.UpdateOffer(Offer);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _offerService.DeleteOffer(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}