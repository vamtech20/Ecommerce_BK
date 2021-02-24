using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class BehaviorProductDto
    {
        public long BehaviorId { get; set; }
        public string BehaviorDesc { get; set; }

        public virtual BehaviorDto Behavior { get; set; }
    }
}
