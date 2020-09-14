using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Province : BaseEntity
    {
        public Province()
        {
            City = new HashSet<City>();
            Company = new HashSet<Company>();
        }

        public int ProvinciaId { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }
        public int ContryId { get; set; }

        public virtual Country Contry { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Company> Company { get; set; }
    }
}
