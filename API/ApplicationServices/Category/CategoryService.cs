using API.DataAccess;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApplicationServices
{
    public class CategoryService : ICategoryService
    {
        #region Fields

        private readonly ICategoryRepository _categoryRepository;

        #endregion

        #region Constructor

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteCategory(long id)
        {
            await _categoryRepository.Delete(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategory(long id)
        {
            return await _categoryRepository.GetAsync(p => p.Id == id);
        }

        public async Task InsertCategory(Category category)
        {
            await _categoryRepository.Insert(category);
        }

        public async Task UpdateCategory(Category category)
        {
            await _categoryRepository.Update(category);
        }

        #endregion
    }
}
