using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Brand : BaseEntity
    {
        public Brand()
        {
            Product = new HashSet<Product>();
        }

        //public int BrandId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
