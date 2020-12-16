using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class PurchaseOrder : BaseEntity
    {
        public PurchaseOrder()
        {
            Products = new HashSet<PurchaseOrderDetail>();
        }

        //public long PurchaseOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int StateId { get; set; }
        public long ClientId { get; set; }
        public long CompanyId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<PurchaseOrderDetail> Products { get; set; }
    }
}
