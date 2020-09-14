using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Subcategory : BaseEntity
    {
        public Subcategory()
        {
            ProductCategory = new HashSet<ProductCategory>();
        }

        public int SubcategoryId { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
