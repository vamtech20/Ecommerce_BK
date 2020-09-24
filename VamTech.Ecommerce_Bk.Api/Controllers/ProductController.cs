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
using VamTech.Ecommerce.Infrastructure.Interfaces;
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
        public IActionResult GetProducts([FromQuery]ProductQueryFilter filters)
        {
            var Products = _ProductService.GetProducts(filters);
            var ProductsDtos = _mapper.Map<IEnumerable<ProductDto>>(Products);

            var metadata = new Metadata
            {
                TotalCount = Products.TotalCount,
                PageSize = Products.PageSize,
                CurrentPage = Products.CurrentPage,
                TotalPages = Products.TotalPages,
                HasNextPage = Products.HasNextPage,
                HasPreviousPage = Products.HasPreviousPage,
                NextPageUrl = _uriService.GetProductPaginationUri(filters, Url.RouteUrl(nameof(GetProducts))).ToString(),
                PreviousPageUrl = _uriService.GetProductPaginationUri(filters, Url.RouteUrl(nameof(GetProducts))).ToString()
            };

            var response = new ApiResponse<IEnumerable<ProductDto>>(ProductsDtos)
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
        public async Task<IActionResult> Product(ProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);

            await _ProductService.InsertProduct(Product);

            ProductDto = _mapper.Map<ProductDto>(Product);
            var response = new ApiResponse<ProductDto>(ProductDto);
            return Ok(response);
        }

        [HttpPut]
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
    }
}