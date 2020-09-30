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

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK9")
                    .IsClustered(false);

                entity.ToTable("Brand", "Products");

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK13")
                    .IsClustered(false);

                entity.ToTable("Category", "Products");

                entity.Property(e => e.Description).HasMaxLength(300);
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

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.HasKey(e => e.FeatureId)
                    .HasName("PK17")
                    .IsClustered(false);

                entity.ToTable("Feature", "Products");

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.OfferId)
                    .HasName("PK7")
                    .IsClustered(false);

                entity.ToTable("Offer", "Offers");

                entity.Property(e => e.TotalPriceOffer).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.OfferType)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.OfferTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefOfferType20");
            });

            modelBuilder.Entity<OfferDetail>(entity =>
            {
                entity.HasKey(e => e.OfferDetailId)
                    .HasName("PK8")
                    .IsClustered(false);

                entity.ToTable("OfferDetail", "Offers");

                entity.Property(e => e.CurrentSalePrice).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.OfferSalePrice).HasColumnType("numeric(15, 2)");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.OfferDetail)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefOffer21");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OfferDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProduct22");
            });

            modelBuilder.Entity<OfferType>(entity =>
            {
                entity.HasKey(e => e.OfferTypeId)
                    .HasName("PK15")
                    .IsClustered(false);

                entity.ToTable("OfferType", "Offers");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.PercDisc2unity).HasColumnType("numeric(3, 2)");

                entity.Property(e => e.PercDiscountDirect).HasColumnType("numeric(3, 2)");
            });

            

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryId)
                    .HasName("PK16")
                    .IsClustered(false);

                entity.ToTable("ProductCategory", "Products");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProduct24");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.SubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefSubcategory25");
            });

            modelBuilder.Entity<ProductFeature>(entity =>
            {
                entity.HasKey(e => e.ProductFeatureId)
                    .HasName("PK20")
                    .IsClustered(false);

                entity.ToTable("ProductFeature", "Products");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.ProductFeature)
                    .HasForeignKey(d => d.FeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefFeature30");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductFeature)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProduct31");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.ProductImageId)
                    .HasName("PK6")
                    .IsClustered(false);

                entity.ToTable("ProductImage", "Products");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.IsPrincipal).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImage)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProduct19");
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

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.HasKey(e => e.SubcategoryId)
                    .HasName("PK13_1")
                    .IsClustered(false);

                entity.ToTable("Subcategory", "Products");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subcategory_Category");
            });

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
