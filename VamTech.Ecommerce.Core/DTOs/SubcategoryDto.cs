using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class SubcategoryDto
    {
        public long Id { get; set; }
        public string Description { get; set; }

        public  CategoryDto Category { get; set; }
        //public  ICollection<ProductCategoryDto> Products { get; set; }
    }
}
