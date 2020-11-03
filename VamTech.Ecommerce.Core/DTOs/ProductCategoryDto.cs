using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class ProductCategoryDto
    {
        //public  ProductDto Product { get; set; }
        public  SubcategoryDto Subcategory { get; set; }

        public string CategoryDesc { get; set; }


    }
}
