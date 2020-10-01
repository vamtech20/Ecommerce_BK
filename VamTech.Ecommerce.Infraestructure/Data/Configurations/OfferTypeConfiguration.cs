using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infrastructure.Data.Configurations
{
    public class OfferTypeConfiguration : IEntityTypeConfiguration<OfferType>
    {
        public void Configure(EntityTypeBuilder<OfferType> builder)
        {
            
            builder.HasKey(e => e.Id)
                    .HasName("PK15")
                    .IsClustered(false);

            builder.Property(e => e.Id)
             .HasColumnName("OfferTypeId");

            builder.ToTable("OfferType", "Offers");

            builder.Property(e => e.Description).HasMaxLength(500);

            builder.Property(e => e.PercDisc2unity).HasColumnType("numeric(3, 2)");

            builder.Property(e => e.PercDiscountDirect).HasColumnType("numeric(3, 2)");

        }
    }
}
