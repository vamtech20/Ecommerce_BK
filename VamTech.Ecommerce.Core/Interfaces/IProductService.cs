using System.Collections.Generic;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.CustomEntities;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.QueryFilters;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts(ProductQueryFilter filters, string actionUrl, out Metadata metadata);

        Task<Product> GetProduct(int id);

        Task InsertProduct(Product product);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(int id);

        IEnumerable<BrandDto> GetBrands();

        Task<bool> HighlighProduct(int id, decimal isFeatured);
    }
}