using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataAccess
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.ToTable("BasketItems");
            builder.HasKey(bi => bi.Id);
            builder.Property(bi => bi.Count).IsRequired();
            builder.Property(bi => bi.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(bi => bi.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(bi => bi.Basket)
                    .WithMany(b => b.BasketItems)
                    .HasForeignKey(bi => bi.BasketId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bi => bi.Product)
                    .WithMany(p => p.BasketItems)
                    .HasForeignKey(bi => bi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion
    }
}
