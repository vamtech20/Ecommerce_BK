using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Infrastructure.Data.Configurations;

namespace VamTech.Ecommerce.Infraestructure.Data
{
    public partial class VamtechEcommerceContext :  IdentityDbContext
    {
        public VamtechEcommerceContext()
        {
        }

        public VamtechEcommerceContext(DbContextOptions<VamtechEcommerceContext> options)
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

            modelBuilder.Entity<Behavior>(entity =>
            {
                entity.HasKey(e => e.BehaviorId)
                    .HasName("PK17_1")
                    .IsClustered(false);

                entity.ToTable("Behavior", "Products");

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<BehaviorProduct>(entity =>
            {
                entity.HasKey(e => e.BehaviorProductId)
                    .HasName("PK19")
                    .IsClustered(false);

                entity.ToTable("BehaviorProduct", "Products");

                entity.HasOne(d => d.Behavior)
                    .WithMany(p => p.BehaviorProduct)
                    .HasForeignKey(d => d.BehaviorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefAction29");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BehaviorProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProduct27");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK10_1")
                    .IsClustered(false);

                entity.ToTable("City", "Logistics");

                entity.Property(e => e.LongDesc).HasMaxLength(100);

                entity.Property(e => e.ShortDesc).HasMaxLength(4);

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProvince15");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK4")
                    .IsClustered(false);

                entity.ToTable("Company", "Logistics");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.IsPos)
                    .HasColumnName("IsPOS")
                    .HasColumnType("numeric(1, 0)");

                entity.Property(e => e.IsSupplier).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.Latitude).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.Length).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PostalCode).HasMaxLength(50);

                entity.Property(e => e.StateId).HasColumnType("numeric(2, 0)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefCity3");

                entity.HasOne(d => d.Contry)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.ContryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefCountry2");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProvince14");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.ContryId)
                    .HasName("PK10_2")
                    .IsClustered(false);

                entity.ToTable("Country", "Logistics");

                entity.Property(e => e.LongDesc).HasMaxLength(100);

                entity.Property(e => e.ShortDesc).HasMaxLength(4);
            });
            
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

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ProvinciaId)
                    .HasName("PK10")
                    .IsClustered(false);

                entity.ToTable("Province", "Logistics");

                entity.Property(e => e.LongDesc).HasMaxLength(100);

                entity.Property(e => e.ShortDesc).HasMaxLength(4);

                entity.HasOne(d => d.Contry)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.ContryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefCountry13");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderId)
                    .HasName("PK3")
                    .IsClustered(false);

                entity.ToTable("PurchaseOrder", "Orders");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefClient16");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefCompany23");
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderDetailId)
                    .HasName("PK5")
                    .IsClustered(false);

                entity.ToTable("PurchaseOrderDetail", "Orders");

                entity.Property(e => e.SalePrice).HasColumnType("numeric(15, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProduct221");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefPurchaseOrder17");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
