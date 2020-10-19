using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class ProductDto
    {
        
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal? SalePrice { get; set; }
        public int Sku { get; set; }
        public long? BarCode { get; set; }
        public string Presentation { get; set; }
        public BrandDto Brand { get; set; }
        public decimal IsFeatured { get; set; }

        public  virtual ICollection<ProductImageDto> Images { get; set; }
        public virtual ICollection<ProductFeatureDto> Features { get; set; }
        public virtual ICollection<OfferDetailDto> Offers { get; set; }

        public OfferDetailDto ActiveOffer { get; set; }

    }
}
