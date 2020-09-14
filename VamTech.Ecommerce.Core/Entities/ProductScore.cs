using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class ProductScore : BaseEntity
    {
        public long ProductScoreId { get; set; }
        public string Comments { get; set; }
        public string Score1to5 { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
