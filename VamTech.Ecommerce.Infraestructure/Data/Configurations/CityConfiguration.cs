using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {

            builder.HasKey(e => e.Id)
                   .HasName("PK10_1")
                   .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("CityId");

            builder.ToTable("City", "Logistics");

            builder.Property(e => e.LongDesc).HasMaxLength(100);

            builder.Property(e => e.ShortDesc).HasMaxLength(20);

            builder.HasOne(d => d.Province)
                .WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefProvince15");


        }

    }
}
