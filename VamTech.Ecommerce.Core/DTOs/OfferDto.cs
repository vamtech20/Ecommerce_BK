using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class OfferDto
    {
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public decimal? TotalPriceOffer { get; set; }

        public OfferTypeDto OfferType { get; set; }

        public virtual ICollection<OfferDetailDto> Details { get; set; }
    }
}
