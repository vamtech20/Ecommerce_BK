using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class City : BaseEntity
    {
        public City()
        {
            Company = new HashSet<Company>();
        }

        public int CityId { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }
        public int ProvinciaId { get; set; }

        public virtual Province Provincia { get; set; }
        public virtual ICollection<Company> Company { get; set; }
    }
}
