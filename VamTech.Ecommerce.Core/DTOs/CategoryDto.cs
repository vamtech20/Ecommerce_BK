using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Description { get; set; }

        public string IconUrl { get; set; }

        public decimal IsFeatured { get; set; }

        public ICollection<SubcategoryDto> Subcategories { get; set; }
    }
}
