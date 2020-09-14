using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Company = new HashSet<Company>();
            Province = new HashSet<Province>();
        }

        public int ContryId { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }

        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<Province> Province { get; set; }
    }
}
