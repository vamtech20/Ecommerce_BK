﻿using System;
using System.Collections.Generic;

namespace VamTech.Ecommerce.Core.Entities
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            BehaviorProduct = new HashSet<BehaviorProduct>();
            OfferDetail = new HashSet<OfferDetail>();
            ProductCategory = new HashSet<ProductCategory>();
            ProductFeature = new HashSet<ProductFeature>();
            Images = new HashSet<ProductImage>();
            ProductScore = new HashSet<ProductScore>();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        //public long ProductId { get; set; }
        public string Description { get; set; }
        public decimal? SalePrice { get; set; }
        public int Sku { get; set; }
        public long? BarCode { get; set; }
        public string Presentation { get; set; }
        public long BrandId { get; set; }
        public decimal IsFeatured { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<BehaviorProduct> BehaviorProduct { get; set; }
        public virtual ICollection<OfferDetail> OfferDetail { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        public virtual ICollection<ProductFeature> ProductFeature { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<ProductScore> ProductScore { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
