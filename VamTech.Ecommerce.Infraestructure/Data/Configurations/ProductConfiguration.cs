using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK2")
                    .IsClustered(false);
            builder.Property(e => e.Id)
             .HasColumnName("ProductId");
            //builder.Property(e => e.ProductId)
            //   .HasColumnName("IdSeguridad");

            builder.ToTable("Product", "Products");

            builder.Property(e => e.Description).HasMaxLength(500);

            builder.Property(e => e.PrecioVenta).HasColumnType("decimal(15, 2)");

            builder.Property(e => e.Presentation).HasMaxLength(200);

            builder.Property(e => e.Sku).HasColumnName("SKU");

            builder.HasOne(d => d.Brand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefBrand1");
            




        }
    }
}
