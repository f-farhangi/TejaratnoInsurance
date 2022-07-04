using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class CategoryController : Controller
    {
        #region Fields

        private readonly ICategoryService _CategoryService;

        #endregion

        #region Constructor

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> CategoryIndex()
        {
            List<CategoryDto> categories = await _CategoryService.GetAllCategoriesAsync<List<CategoryDto>>();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryCreate(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                var response = await _CategoryService.CreateCategoryAsync<CategoryDto>(category);

                if (response != null)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryUpdate(long categoryId)
        {
            var response = await _CategoryService.GetCategoryByIdAsync<CategoryDto>(categoryId);

            if (response != null)
            {
                return View(response);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryUpdate(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                var response = await _CategoryService.UpdateCategoryAsync<CategoryDto>(category);

                if (response != null)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryDelete(int categoryId)
        {
            var response = await _CategoryService.GetCategoryByIdAsync<CategoryDto>(categoryId);

            if (response != null)
            {
                return View(response);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryDelete(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                var response = await _CategoryService.DeleteCategorysAsync<CategoryDto>(category.Id);
                return RedirectToAction(nameof(CategoryIndex));
            }

            return View(category);
        }

        #endregion
    }
}
