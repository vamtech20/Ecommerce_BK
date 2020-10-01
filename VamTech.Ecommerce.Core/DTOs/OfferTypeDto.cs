using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class OfferTypeDto
    {
        public string Description { get; set; }
        public decimal? PercDiscountDirect { get; set; }
        public int? PayN { get; set; }
        public int? TakeM { get; set; }
        public decimal? PercDisc2unity { get; set; }
    }
}
