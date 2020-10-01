using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infrastructure.Data.Configurations
{
    public class OfferDetailConfiguration : IEntityTypeConfiguration<OfferDetail>
    {
        public void Configure(EntityTypeBuilder<OfferDetail> builder)
        {
            builder.HasKey(e => e.Id)
                   .HasName("PK8")
                   .IsClustered(false);

            builder.Property(e => e.Id)
             .HasColumnName("OfferDetailId");

            builder.ToTable("OfferDetail", "Offers");

            builder.Property(e => e.CurrentSalePrice).HasColumnType("numeric(15, 2)");

            builder.Property(e => e.OfferSalePrice).HasColumnType("numeric(15, 2)");

            builder.HasOne(d => d.Offer)
                .WithMany(p => p.Details)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefOffer21");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.OfferDetail)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefProduct22");

        }
    }
}
