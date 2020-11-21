using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {

            builder.HasKey(e => e.Id)
                    .HasName("PK10")
                    .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("ProvinceId");

            builder.ToTable("Province", "Logistics");

            builder.Property(e => e.LongDesc).HasMaxLength(100);

            builder.Property(e => e.ShortDesc).HasMaxLength(4);

            builder.HasOne(d => d.Country)
                .WithMany(p => p.Provinces)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCountry13");


        }

    }
}
