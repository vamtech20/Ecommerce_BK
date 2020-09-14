using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Offer : BaseEntity
    { 
        public Offer()
        {
            OfferDetail = new HashSet<OfferDetail>();
        }

        public long OfferId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public decimal? TotalPriceOffer { get; set; }
        public int OfferTypeId { get; set; }

        public virtual OfferType OfferType { get; set; }
        public virtual ICollection<OfferDetail> OfferDetail { get; set; }
    }
}
