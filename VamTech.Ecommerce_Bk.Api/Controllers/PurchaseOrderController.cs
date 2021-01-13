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
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IMailService _mailService;

        public PurchaseOrderController(IOrderService orderService, IMapper mapper, IUriService uriService, IMailService mailService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _uriService = uriService;
            _mailService = mailService;
        }

        /// <summary>
        /// Retrieve all Purcharse Orders
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetPurchaseOrders))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PurchaseOrderDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[Authorize(Policy = "PolicyCliente")]
        public IActionResult GetPurchaseOrders([FromQuery]PurchaseOrderQueryFilter filters)
        {
            
            var metadata = new Metadata();

            var ords =_orderService.GetPurchaseOrders(filters, Url.RouteUrl(nameof(GetPurchaseOrders)), out metadata);

            var response = new ApiResponse<IEnumerable<PurchaseOrderDto>>(ords)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseOrder(int id)
        {
            var po = await _orderService.GetPurchaseOrder(id);
            var poDto = _mapper.Map<PurchaseOrderDto>(po);
            var response = new ApiResponse<PurchaseOrderDto>(poDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PurchaseOrder(PurchaseOrderDto poDto)
        {
            await _orderService.InsertPurchaseOrder(poDto);
            var response = new ApiResponse<PurchaseOrderDto>(poDto);

            

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PurchaseOrderDto poDto)
        {
            var result = await _orderService.UpdatePurchaseOrder(poDto);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeletePurchaseOrder(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}