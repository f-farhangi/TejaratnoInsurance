using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        #endregion

        #region Constructor

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> products = await _productService.GetAllProductsAsync<List<ProductDto>>();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync<List<CategoryDto>>().GetAwaiter().GetResult();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ProductDto>(product);

                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> ProductUpdate(long productId)
        {
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync<List<CategoryDto>>().GetAwaiter().GetResult();

            var response = await _productService.GetProductByIdAsync<ProductDto>(productId);

            if (response != null)
            {
                return View(response);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductUpdate(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync<ProductDto>(product);

                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ProductDto>(productId);

            if (response != null)
            {
                return View(response);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteProductsAsync<ProductDto>(product.Id);
                return RedirectToAction(nameof(ProductIndex));
            }

            return View(product);
        }

        #endregion
    }
}
