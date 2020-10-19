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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ProductService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMapper mapper, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _mapper = mapper;
            _uriService = uriService;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public IEnumerable<ProductDto> GetProducts(ProductQueryFilter filters, string actionUrl, out Metadata metadata)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            filters.TextToFind = filters.TextToFind is null ? string.Empty : filters.TextToFind;

            var Products = _unitOfWork.ProductRepository.GetAll().Where(x => x.IsFeatured == filters.IsFeatured
                                      && (x.LongDesc.ToUpper().Contains(filters.TextToFind.ToUpper()) || filters.TextToFind.Trim().Length == 0)
                                     //&&(x.Categories.Any(x=> x.SubcategoryId == filters.CategoryId || filters.CategoryId == 0))
                                     );

            var pagedProducts = PagedList<Product>.Create(Products, filters.PageNumber, filters.PageSize);
                        
            var ProductsDtos = _mapper.Map<IEnumerable<ProductDto>>(pagedProducts);
            
            metadata = new Metadata
            {
                TotalCount = pagedProducts.TotalCount,
                PageSize = pagedProducts.PageSize,
                CurrentPage = pagedProducts.CurrentPage,
                TotalPages = pagedProducts.TotalPages,
                HasNextPage = pagedProducts.HasNextPage,
                HasPreviousPage = pagedProducts.HasPreviousPage,
                NextPageUrl = _uriService.GetProductPaginationUri(filters, actionUrl).ToString(),
                PreviousPageUrl = _uriService.GetProductPaginationUri(filters, actionUrl).ToString()
            };


            return ProductsDtos;
           
        }

        public async Task InsertProduct(Product Product)
        {
            
            await _unitOfWork.ProductRepository.Add(Product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(Product Product)
        {
            var existingProduct = await _unitOfWork.ProductRepository.GetById(Product.Id);
           
            //existingProduct.Image = Product.Image;
            //existingProduct.Description = Product.Description;

            _unitOfWork.ProductRepository.Update(existingProduct);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
