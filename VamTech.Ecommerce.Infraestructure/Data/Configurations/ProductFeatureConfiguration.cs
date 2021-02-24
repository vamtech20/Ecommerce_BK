using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {

            builder.HasKey(e => e.Id)
                    .HasName("PK20")
                    .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("ProductFeatureId");

            builder.ToTable("ProductFeature", "Products");

            builder.HasOne(d => d.Feature)
                    .WithMany(p => p.ProductFeature)
                    .HasForeignKey(d => d.FeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefFeature30");

            builder.HasOne(d => d.Product)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProduct31");
            

        }

    }
}
