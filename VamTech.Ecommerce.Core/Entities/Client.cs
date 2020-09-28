using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Client : BaseEntity
    {
        public Client()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        //public long ClientId { get; set; }
        public decimal? Document { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
