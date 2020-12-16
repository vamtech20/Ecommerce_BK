using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class PurchaseOrderDetailConfiguration : IEntityTypeConfiguration<PurchaseOrderDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {


            builder.HasKey(e => e.Id)
                    .HasName("PK5")
                    .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("PurchaseOrderDetailId");

            builder.ToTable("PurchaseOrderDetail", "Orders");

            builder.Property(e => e.SalePrice).HasColumnType("numeric(15, 2)");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.PurchaseOrderDetail)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefProduct221");

            builder.HasOne(d => d.PurchaseOrder)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefPurchaseOrder17");


        }

    }
}
