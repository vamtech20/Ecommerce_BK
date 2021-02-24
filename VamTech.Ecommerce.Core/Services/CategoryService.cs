using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.CustomEntities;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.Exceptions;
using VamTech.Ecommerce.Core.Interfaces;
using VamTech.Ecommerce.Core.QueryFilters;

namespace VamTech.Ecommerce.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public CategoryService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMapper mapper, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _mapper = mapper;
            _uriService = uriService;
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _unitOfWork.CategoryRepository.GetById(id);
        }

        public IEnumerable<CategoryDto> GetCategories(CategoryQueryFilter filters, string actionUrl, out Metadata metadata)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            filters.IsFeatured = filters.IsFeatured is null ? -1 : filters.IsFeatured;


            var Cateogories = _unitOfWork.CategoryRepository.GetAll().Where(x => (x.IsFeatured == filters.IsFeatured || filters.IsFeatured == -1)
                                                                           );

            var pagedCategories = PagedList<Category>.Create(Cateogories, filters.PageNumber, filters.PageSize);
                        
            var CategoriesDtos = _mapper.Map<IEnumerable<CategoryDto>>(pagedCategories);
            
            metadata = new Metadata
            {
                TotalCount = pagedCategories.TotalCount,
                PageSize = pagedCategories.PageSize,
                CurrentPage = pagedCategories.CurrentPage,
                TotalPages = pagedCategories.TotalPages,
                HasNextPage = pagedCategories.HasNextPage,
                HasPreviousPage = pagedCategories.HasPreviousPage,
                NextPageUrl = _uriService.GetCategoryPaginationUri(filters, actionUrl).ToString(),
                PreviousPageUrl = _uriService.GetCategoryPaginationUri(filters, actionUrl).ToString()
            };


            return CategoriesDtos;
           
        }

        //public async Task InsertProduct(Product Product)
        //{
            
        //    await _unitOfWork.ProductRepository.Add(Product);
        //    await _unitOfWork.SaveChangesAsync();
        //}

        //public async Task<bool> UpdateProduct(Product Product)
        //{
        //    var existingProduct = await _unitOfWork.ProductRepository.GetById(Product.Id);
           
        //    //existingProduct.Image = Product.Image;
        //    //existingProduct.Description = Product.Description;

        //    _unitOfWork.ProductRepository.Update(existingProduct);
        //    await _unitOfWork.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<bool> DeleteProduct(int id)
        //{
        //    await _unitOfWork.ProductRepository.Delete(id);
        //    await _unitOfWork.SaveChangesAsync();
        //    return true;
        //}
    }
}
