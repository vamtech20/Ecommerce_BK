using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Company : BaseEntity
    {
        public Company()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal? Length { get; set; }
        public decimal StateId { get; set; }
        public string PostalCode { get; set; }
        public int ContryId { get; set; }
        public int CityId { get; set; }
        public int ProvinciaId { get; set; }
        public decimal IsSupplier { get; set; }
        public decimal IsPos { get; set; }

        public virtual City City { get; set; }
        public virtual Country Contry { get; set; }
        public virtual Province Provincia { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
