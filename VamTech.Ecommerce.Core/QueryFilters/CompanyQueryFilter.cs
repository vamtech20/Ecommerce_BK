using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.QueryFilters
{
    public class CompanyQueryFilter
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int? IsPos { get; set; }
    }
}
