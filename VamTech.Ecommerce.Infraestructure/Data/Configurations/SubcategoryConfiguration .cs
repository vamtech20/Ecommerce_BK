using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Infraestructure.Data.Configurations
{
    public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {

            builder.HasKey(e => e.Id)
                    .HasName("PK13_1")
                    .IsClustered(false);

            builder.Property(e => e.Id).HasColumnName("SubcategoryId");

            builder.ToTable("Subcategory", "Products");

            builder.Property(e => e.Description).HasMaxLength(300);

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Subcategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subcategory_Category");


        }

    }
}
