using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        #region Constructor

        public BasketRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods
        #endregion
    }
}
