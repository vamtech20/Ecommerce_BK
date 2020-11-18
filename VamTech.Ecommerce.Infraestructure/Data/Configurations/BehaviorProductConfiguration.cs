using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class BehaviorProductConfiguration : IEntityTypeConfiguration<BehaviorProduct>
    {
        public void Configure(EntityTypeBuilder<BehaviorProduct> builder)
        {


            builder.HasKey(e => e.Id)
                   .HasName("PK19")
                   .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("BehaviorProductId");

            builder.ToTable("BehaviorProduct", "Products");

            builder.HasOne(d => d.Behavior)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.BehaviorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefAction29");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Behaviors)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefProduct27");


        }

    }
}
