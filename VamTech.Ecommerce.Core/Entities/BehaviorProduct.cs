using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class BehaviorProduct : BaseEntity
    {
        public long BehaviorProductId { get; set; }
        public long ProductId { get; set; }
        public int BehaviorId { get; set; }

        public virtual Behavior Behavior { get; set; }
        public virtual Product Product { get; set; }
    }
}
