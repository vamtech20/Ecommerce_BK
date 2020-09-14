using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Behavior : BaseEntity
    {
        public Behavior()
        {
            BehaviorProduct = new HashSet<BehaviorProduct>();
        }

        public int BehaviorId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BehaviorProduct> BehaviorProduct { get; set; }
    }
}
