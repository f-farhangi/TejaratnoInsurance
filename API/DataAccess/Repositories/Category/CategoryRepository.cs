using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        #region Constructor

        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods
        #endregion
    }
}
