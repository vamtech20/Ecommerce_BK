using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.QueryFilters
{
    public class PurchaseOrderQueryFilter
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public DateTime OrderDateFrom { get; set; }

        public DateTime OrderDateTo { get; set; }

        public long? CompanyId { get; set; }

        public decimal? Document { get; set; }

        public int? StateId { get; set; }

        
        
    }
}
