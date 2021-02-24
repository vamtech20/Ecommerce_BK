using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Infraestructure.Data.Configurations;

namespace VamTech.Ecommerce.Infraestructure.Data
{
    public partial class VamTechEcommerceContext :  IdentityDbContext
    {
        public VamTechEcommerceContext()
        {
        }

        public VamTechEcommerceContext(DbContextOptions<VamTechEcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Behavior> Behavior { get; set; }
        public virtual DbSet<BehaviorProduct> BehaviorProduct { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<OfferDetail> OfferDetail { get; set; }
        public virtual DbSet<OfferType> OfferType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductFeature> ProductFeature { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<ProductScore> ProductScore { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }
               

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                       

                     
            modelBuilder.Entity<ProductScore>(entity =>
            {
                entity.HasKey(e => e.ProductScoreId)
                    .HasName("PK22")
                    .IsClustered(false);

                entity.ToTable("ProductScore", "Products");

                entity.Property(e => e.Comments).HasMaxLength(1000);

                entity.Property(e => e.Score1to5)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductScore)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProduct32");
            });
            
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new OfferDetailConfiguration());
            modelBuilder.ApplyConfiguration(new OfferTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BehaviorConfiguration());
            modelBuilder.ApplyConfiguration(new BehaviorProductConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderDetailConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
