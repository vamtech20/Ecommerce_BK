using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {

            builder.HasKey(e => e.Id)
                   .HasName("PK6")
                   .IsClustered(false);

            builder.Property(e => e.Id)
             .HasColumnName("ProductImageId");

            builder.ToTable("ProductImage", "Products");
                    

            builder.Property(e => e.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(e => e.IsPrincipal).HasColumnType("numeric(1, 0)");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefProduct19");

        }
    }
}
