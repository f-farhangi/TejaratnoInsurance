using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataAccess
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Baskets");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.ClientBasketId).IsRequired().HasMaxLength(50);
            builder.Property(b => b.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
        }

        #endregion
    }
}
