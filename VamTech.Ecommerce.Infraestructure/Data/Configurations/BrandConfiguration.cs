using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infrastructure.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {

            builder.HasKey(e => e.Id)
                    .HasName("PK9")
                    .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("BrandId");

            builder.ToTable("Brand", "Products");

            builder.Property(e => e.Description).HasMaxLength(200);

        }

    }
}
