using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Feature : BaseEntity
    {
        public Feature()
        {
            ProductFeature = new HashSet<ProductFeature>();
        }

        public int FeatureId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductFeature> ProductFeature { get; set; }
    }
}
