using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.HasKey(e => e.Id)
                    .HasName("PK1")
                    .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("ClientId");
            
            builder.ToTable("Client", "Orders");

            builder.Property(e => e.Document).HasColumnType("numeric(10, 0)");

            builder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(e => e.HomePhone).HasMaxLength(20);

            builder.Property(e => e.Email)
                 .IsRequired()
                 .HasMaxLength(100); 

            builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(e => e.MobilePhone).HasMaxLength(20);
          
        }

    }
}
