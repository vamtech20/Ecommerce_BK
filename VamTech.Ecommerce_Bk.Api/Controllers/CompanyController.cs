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
    public class CompanyController : ControllerBase
    {
        private readonly ILogisticService _logisticService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public CompanyController(ILogisticService logisticService, IMapper mapper, IUriService uriService)
        {
            _logisticService = logisticService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all Brands
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetCompanies))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CompanyDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetCompanies([FromQuery] CompanyQueryFilter filters)
        {
            var metadata = new Metadata();

            var companies = _logisticService.GetCompanies(filters, Url.RouteUrl(nameof(GetCompanies)), out metadata);

            var response = new ApiResponse<IEnumerable<CompanyDto>>(companies)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);

           
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var Company = await _logisticService.GetCompany(id);
            var CompanyDto = _mapper.Map<CompanyDto>(Company);
            var response = new ApiResponse<CompanyDto>(CompanyDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Company(CompanyDto CompanyDto)
        {
           
            await _logisticService.InsertCompany(CompanyDto);
                        
            var response = new ApiResponse<CompanyDto>(CompanyDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CompanyDto CompanyDto)
        {

            CompanyDto.Id = id;

            var result = await _logisticService.UpdateCompany(CompanyDto);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _logisticService.DeleteCompany(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


    }
}