using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class PurchaseOrderDetail : BaseEntity
    {
        public long PurchaseOrderDetailId { get; set; }
        public decimal? SalePrice { get; set; }
        public int Quantity { get; set; }
        public int StateId { get; set; }
        public long PurchaseOrderId { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
