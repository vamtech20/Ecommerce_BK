using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class ProductImageDto
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public decimal IsPrincipal { get; set; }
    }
}
