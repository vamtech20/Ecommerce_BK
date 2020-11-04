using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(e => e.Id)
                   .HasName("PK13")
                   .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("CategoryId");

            builder.ToTable("Category", "Products");

            builder.Property(e => e.Description).HasMaxLength(300);

            builder.Property(e => e.IconUrl).HasMaxLength(300);

            builder.Property(e => e.IsFeatured).HasColumnType("numeric(1, 0)");


        }

    }
}
