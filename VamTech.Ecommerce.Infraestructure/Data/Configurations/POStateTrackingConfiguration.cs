using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class POStateTrackingConfiguration : IEntityTypeConfiguration<POStateTracking>
    {
        public void Configure(EntityTypeBuilder<POStateTracking> builder)
        {


            builder.HasKey(e => e.Id)
                    .HasName("PK_POStateTracking")
                    .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("POStateTrackingId");

            builder.ToTable("POStateTracking", "dbo");

            builder.Property(e => e.Comments).HasMaxLength(1000);



        }

    }
}
