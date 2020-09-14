using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class OfferType : BaseEntity
    {
        public OfferType()
        {
            Offer = new HashSet<Offer>();
        }

        public int OfferTypeId { get; set; }
        public string Description { get; set; }
        public decimal? PercDiscountDirect { get; set; }
        public int? PayN { get; set; }
        public int? TakeM { get; set; }
        public decimal? PercDisc2unity { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }
    }
}
