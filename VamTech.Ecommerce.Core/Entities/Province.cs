using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Province : BaseEntity
    {
        public Province()
        {
            Cities = new HashSet<City>();
            Companies = new HashSet<Company>();
        }

        //public int ProvinceId { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }
        public long CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
