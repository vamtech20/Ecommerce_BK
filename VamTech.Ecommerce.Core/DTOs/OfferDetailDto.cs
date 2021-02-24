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
        
        public long ProductId { get; set; }

        public ProductDto Product { get; set; }
        public OfferDto Offer { get; set; }
    }
}
