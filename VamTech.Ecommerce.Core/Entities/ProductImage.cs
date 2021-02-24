using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class ProductImage : BaseEntity
    {
        //public long ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public decimal IsPrincipal { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        //public string Base64 { get; set; }
    }
}
