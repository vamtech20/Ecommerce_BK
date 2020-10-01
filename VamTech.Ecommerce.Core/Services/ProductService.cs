using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.CustomEntities;
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

        public ProductService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public PagedList<Product> GetProducts(ProductQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var Products = _unitOfWork.ProductRepository.GetAll().Where(x=> x.IsFeatured == filters.IsFeatured);

            
            var pagedProducts = PagedList<Product>.Create(Products, filters.PageNumber, filters.PageSize);
            return pagedProducts;
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
