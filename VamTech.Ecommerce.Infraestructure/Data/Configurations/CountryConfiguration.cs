using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {


            builder.HasKey(e => e.Id)
                   .HasName("PK10_2")
                   .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("CountryId");

            builder.ToTable("Country", "Logistics");

            builder.Property(e => e.LongDesc).HasMaxLength(100);

            builder.Property(e => e.ShortDesc).HasMaxLength(4);




        }

    }
}
