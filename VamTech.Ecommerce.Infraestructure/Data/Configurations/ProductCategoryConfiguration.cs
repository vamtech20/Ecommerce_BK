using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infrastructure.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {

            builder.HasKey(e => e.Id)
                   .HasName("PK16")
                   .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("ProductCategoryId");

            builder.ToTable("ProductCategory", "Products");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefProduct24");

            builder.HasOne(d => d.Subcategory)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.SubcategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefSubcategory25");


        }

    }
}
