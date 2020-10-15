using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infrastructure.Data.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {

            builder.HasKey(e => e.Id)
                    .HasName("PK17")
                    .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("FeatureId");

            builder.ToTable("Feature", "Products");

            builder.Property(e => e.Description).HasMaxLength(500);
                     

        }

    }
}
