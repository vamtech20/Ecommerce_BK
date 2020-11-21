using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class City : BaseEntity
    {
        public City()
        {
            Companies = new HashSet<Company>();
        }

        //public int CityId { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }
        public long ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
