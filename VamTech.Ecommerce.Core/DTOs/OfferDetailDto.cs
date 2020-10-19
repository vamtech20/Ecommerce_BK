using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class OfferDetailDto
    {
       
        public decimal? CurrentSalePrice { get; set; }
        public decimal? OfferSalePrice { get; set; }
        public int? StockToSellOut { get; set; }
        public decimal? TotalPriceOffer { get; set; }
        public string Description { get; set; }
        public decimal? PercDiscountDirect { get; set; }
        public int? PayN { get; set; }
        public int? TakeM { get; set; }
        public decimal? PercDisc2unity { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        //public ProductDto Product { get; set; }
        //public OfferDto Offer { get; set; }
    }
}
