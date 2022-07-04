using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.ApplicationServices
{
    public interface ICategoryService
    {
        #region Methods

        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(long id);
        Task InsertCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(long id);

        #endregion
    }
}
