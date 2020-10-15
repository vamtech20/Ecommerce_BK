using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class ProductCategory : BaseEntity
    {
        //public long ProductCategoryId { get; set; }
        public long ProductId { get; set; }
        public long SubcategoryId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}
