using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

            builder.HasKey(e => e.Id )
                .HasName("PK4")
                .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("CompanyId");

            builder.ToTable("Company", "Logistics");

            builder.Property(e => e.Address).HasMaxLength(200);

            builder.Property(e => e.IsPos)
                .HasColumnName("IsPOS")
                .HasColumnType("numeric(1, 0)");

            builder.Property(e => e.IsSupplier).HasColumnType("numeric(1, 0)");

            builder.Property(e => e.Latitude).HasColumnType("numeric(10, 6)");

            builder.Property(e => e.Length).HasColumnType("numeric(10, 6)");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PostalCode).HasMaxLength(50);

            builder.Property(e => e.StateId).HasColumnType("numeric(2, 0)");

            builder.HasOne(d => d.City)
                .WithMany(p => p.Companies)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCity3");

            builder.HasOne(d => d.Country)
                .WithMany(p => p.Companies)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCountry2");

            builder.HasOne(d => d.Province)
                .WithMany(p => p.Companies)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefProvince14");

           


        }

    }
}
