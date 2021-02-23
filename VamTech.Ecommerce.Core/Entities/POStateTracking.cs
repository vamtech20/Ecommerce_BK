using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class POStateTracking : BaseEntity
    {
        //public long POStateTrackingId { get; set; }

        public int StateId { get; set; }
        public long PurchaseOrderId { get; set; }
        public DateTime UpdateDate { get; set; }

        public string Comments { get; set; }


        //public virtual PurchaseOrder Orders { get; set; }
    }
}
