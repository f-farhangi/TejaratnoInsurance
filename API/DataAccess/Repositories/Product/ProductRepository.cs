using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        #region Constructor

        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods
        #endregion
    }
}
