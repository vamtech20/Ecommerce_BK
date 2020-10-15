using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class CategoryDto
    {
        public string Description { get; set; }

        public ICollection<SubcategoryDto> Subcategories { get; set; }
    }
}
