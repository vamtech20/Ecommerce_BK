using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.QueryFilters
{
    public class ProductQueryFilter
    {
        public decimal? IsFeatured { get; set; }

        public string TextToFind { get; set; }

        public long? CategoryId { get; set; }

        public long? SubcategoryId { get; set; }

        public decimal? OrderingCriterionId { get; set; }
        
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
