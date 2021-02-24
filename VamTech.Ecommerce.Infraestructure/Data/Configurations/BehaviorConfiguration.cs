using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class BehaviorConfiguration : IEntityTypeConfiguration<Behavior>
    {
        public void Configure(EntityTypeBuilder<Behavior> builder)
        {

            builder.HasKey(e => e.Id)
                  .HasName("PK17_1")
                  .IsClustered(false);
            builder.Property(e => e.Id).HasColumnName("BehaviorId");

            builder.ToTable("Behavior", "Products");

            builder.Property(e => e.Description).HasMaxLength(500);


        }

    }
}
