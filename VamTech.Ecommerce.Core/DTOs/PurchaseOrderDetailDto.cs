using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class PurchaseOrderDetailDto
    {

        public decimal? SalePrice { get; set; }
        public int Quantity { get; set; }
        public int StateId { get; set; }
        public long PurchaseOrderId { get; set; }
        public long ProductId { get; set; }

        public ProductDto Product { get; set; }
        public PurchaseOrderDto PurchaseOrder { get; set; }

    }
}
