using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataAccess
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ImageUrl).HasMaxLength(1000);
            builder.Property(p => p.Description).HasMaxLength(250);
            builder.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
        }

        #endregion
    }
}
