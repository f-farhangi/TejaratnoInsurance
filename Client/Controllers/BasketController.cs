using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class BasketController : Controller
    {
        #region Fields

        private readonly IBasketService _basketService;

        #endregion

        #region Constructor

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> BasketIndex()
        {
            string basketId = GetCartId();

            BasketDto basket = await _basketService.GetBasketByIdAsync<BasketDto>(basketId);
            return View(basket);
        }

        [HttpGet]
        public async Task<IActionResult> AddToBasket(long productId)
        {
            string basketId = GetCartId();

            BasketItemToAddDto basketItem = new()
            {
                ClientBasketId = basketId,
                ProductId = productId,
                Count = 1
            };

            await _basketService.AddItemToBasketAsync<BasketItemToAddDto>(basketItem);
            return RedirectToAction("ProductIndex", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromBasket(long basketItemId)
        {
            string basketId = GetCartId();

            BasketItemToRemoveDto basketItem = new()
            {
                ClientBasketId = basketId,
                BasketItemId = basketItemId
            };

            await _basketService.RemoveItemFromBasketAsync<BasketItemToRemoveDto>(basketItem);
            return RedirectToAction(nameof(BasketIndex));
        }

        [HttpGet]
        public async Task<IActionResult> IncreaseItem(long productId)
        {
            string basketId = GetCartId();

            OperationalBasketItemDto basketItem = new()
            {
                ClientBasketId = basketId,
                ProductId = productId
            };

            await _basketService.IncreaseItem<OperationalBasketItemDto>(basketItem);
            return RedirectToAction(nameof(BasketIndex));
        }

        [HttpGet]
        public async Task<IActionResult> DecreaseItem(long productId)
        {
            string basketId = GetCartId();

            OperationalBasketItemDto basketItem = new()
            {
                ClientBasketId = basketId,
                ProductId = productId
            };

            await _basketService.DecreaseItem<OperationalBasketItemDto>(basketItem);
            return RedirectToAction(nameof(BasketIndex));
        }

        public string GetCartId()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("BasketId")))
            {
                string basketId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("BasketId", basketId);
            }

            return HttpContext.Session.GetString("BasketId");
        }

        #endregion
    }
}
