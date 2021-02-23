using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.DTOs
{
    public partial class POStateTrackingDto 
    {
        

        public int StateId { get; set; }
        public long PurchaseOrderId { get; set; }
        public DateTime UpdateDate { get; set; }

        public string Comments { get; set; }


        //public virtual PurchaseOrderDto PurchaseOrder { get; set; }
    }
}
