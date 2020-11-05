using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.QueryFilters
{
    public class CategoryQueryFilter
    {
        public decimal? IsFeatured { get; set; }
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
