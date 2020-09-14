using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class ProductDto
    {
        public long ProductId { get; set; }
        public string Description { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int Sku { get; set; }
        public long? BarCode { get; set; }
        public string Presentation { get; set; }
        public int BrandId { get; set; }
    }
}
