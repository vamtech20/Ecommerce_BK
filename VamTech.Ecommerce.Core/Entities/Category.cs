using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Category : BaseEntity
    {
        public Category()
        {
            Subcategory = new HashSet<Subcategory>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
}
