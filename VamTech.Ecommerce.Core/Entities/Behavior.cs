﻿using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Behavior : BaseEntity
    {
        public Behavior()
        {
            Products = new HashSet<BehaviorProduct>();
        }

        //public int BehaviorId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BehaviorProduct> Products { get; set; }
    }
}
