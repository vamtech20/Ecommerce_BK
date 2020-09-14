using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class OfferDetail : BaseEntity
    {
        public long OfferDetailId { get; set; }
        public decimal? CurrentSalePrice { get; set; }
        public decimal? OfferSalePrice { get; set; }
        public int? StockToSellOut { get; set; }
        public long OfferId { get; set; }
        public long ProductId { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual Product Product { get; set; }
    }
}
