using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class ProductFeature : BaseEntity
    {
        //public long ProductFeatureId { get; set; }
        public long FeatureId { get; set; }
        public long ProductId { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual Product Product { get; set; }
    }
}
