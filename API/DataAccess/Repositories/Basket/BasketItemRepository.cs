using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess
{
    public class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
    {
        #region Constructor

        public BasketItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods
        #endregion
    }
}
