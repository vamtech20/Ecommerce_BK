using System.Collections.Generic;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.CustomEntities;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.QueryFilters;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories(CategoryQueryFilter filters, string actionUrl, out Metadata metadata);

    }
}