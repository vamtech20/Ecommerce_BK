using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{ 
    public class PurchaseOrderDto
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int StateId { get; set; }
        public long ClientId { get; set; }
        public long CompanyId { get; set; }

        public decimal TotalInvoiced { get; set; }

        public virtual ClientDto Client { get; set; }
        public virtual CompanyDto Company { get; set; }
        public virtual ICollection<PurchaseOrderDetailDto> Products { get; set; }

    }
}
