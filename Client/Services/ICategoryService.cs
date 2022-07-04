using Client.Models;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface ICategoryService : IBaseService
    {
        #region Methods

        Task<T> GetAllCategoriesAsync<T>();
        Task<T> GetCategoryByIdAsync<T>(long categoryId);
        Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto);
        Task<T> UpdateCategoryAsync<T>(CategoryDto categoryDto);
        Task<T> DeleteCategorysAsync<T>(long categoryId);

        #endregion
    }
}
