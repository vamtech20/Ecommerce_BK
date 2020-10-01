using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infrastructure.Data.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK7")
                    .IsClustered(false);

            builder.Property(e => e.Id)
             .HasColumnName("OfferId");

            builder.ToTable("Offer", "Offers");

            builder.Property(e => e.TotalPriceOffer).HasColumnType("numeric(15, 2)");

            builder.Property(e => e.ValidFrom).HasColumnType("datetime");

            builder.Property(e => e.ValidTo).HasColumnType("datetime");

            builder.HasOne(d => d.OfferType)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.OfferTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefOfferType20");
           
        }
    }
}
