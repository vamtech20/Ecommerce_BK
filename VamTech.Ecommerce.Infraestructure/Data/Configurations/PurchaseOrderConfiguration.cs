using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {

            builder.HasKey(e => e.Id)
                    .HasName("PK3")
                    .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("PurchaseOrderId");

            builder.ToTable("PurchaseOrder", "Orders");

            builder.Property(e => e.TotalInvoiced).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.OrderDate).HasColumnType("datetime");

            builder.HasOne(d => d.Client)
                .WithMany(p => p.PurchaseOrder)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefClient16");

            builder.HasOne(d => d.Company)
                .WithMany(p => p.PurchaseOrder)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCompany23");

        }

    }
}
