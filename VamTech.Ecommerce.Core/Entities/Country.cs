using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Companies = new HashSet<Company>();
            Provinces = new HashSet<Province>();
        }

        //public int ContryId { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
