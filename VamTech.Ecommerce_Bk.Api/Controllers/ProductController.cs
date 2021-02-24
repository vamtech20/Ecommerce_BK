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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ProductController(IProductService ProductService, IMapper mapper, IUriService uriService)
        {
            _ProductService = ProductService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all Products
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetProducts))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[Authorize(Policy = "PolicyCliente")]
        public IActionResult GetProducts([FromQuery]ProductQueryFilter filters)
        {
            
            var metadata = new Metadata();

            var prds =_ProductService.GetProducts(filters, Url.RouteUrl(nameof(GetProducts)), out metadata);

            var response = new ApiResponse<IEnumerable<ProductDto>>(prds)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var Product = await _ProductService.GetProduct(id);
            var ProductDto = _mapper.Map<ProductDto>(Product);
            var response = new ApiResponse<ProductDto>(ProductDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Product(ProductDto dto)
        {
            //var Product = _mapper.Map<Product>(ProductDto);

            await _ProductService.InsertProduct(dto);

            //ProductDto = _mapper.Map<ProductDto>(Product);
            var response = new ApiResponse<ProductDto>(dto);
            return Ok(response);
        }

        [HttpPut("Put")]
        public async Task<IActionResult> Put(int id, ProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            Product.Id = id;

            var result = await _ProductService.UpdateProduct(Product);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ProductService.DeleteProduct(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpPut("Highligh")]
        public async Task<IActionResult> Highligh(int id, decimal isFeatured)
        {
            
            var result = await _ProductService.HighlighProduct(id, isFeatured);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}