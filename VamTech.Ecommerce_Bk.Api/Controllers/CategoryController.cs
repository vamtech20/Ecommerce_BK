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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IUriService uriService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all Categorys
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetCategories))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CategoryDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetCategories([FromQuery]CategoryQueryFilter filters)
        {
            
            var metadata = new Metadata();

            var prds =_categoryService.GetCategories(filters, Url.RouteUrl(nameof(GetCategories)), out metadata);

            var response = new ApiResponse<IEnumerable<CategoryDto>>(prds)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCategory(int id)
        //{
        //    var Category = await _categoryService.GetCategory(id);
        //    var CategoryDto = _mapper.Map<CategoryDto>(Category);
        //    var response = new ApiResponse<CategoryDto>(CategoryDto);
        //    return Ok(response);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Category(CategoryDto CategoryDto)
        //{
        //    var Category = _mapper.Map<Category>(CategoryDto);

        //    await _CategoryService.InsertCategory(Category);

        //    CategoryDto = _mapper.Map<CategoryDto>(Category);
        //    var response = new ApiResponse<CategoryDto>(CategoryDto);
        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put(int id, CategoryDto CategoryDto)
        //{
        //    var Category = _mapper.Map<Category>(CategoryDto);
        //    Category.Id = id;

        //    var result = await _CategoryService.UpdateCategory(Category);
        //    var response = new ApiResponse<bool>(result);
        //    return Ok(response);
        //}


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _CategoryService.DeleteCategory(id);
        //    var response = new ApiResponse<bool>(result);
        //    return Ok(response);
        //}
    }
}