using API.DataAccess;
using API.Entities;
using API.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ApplicationServices
{
    public class BasketService : IBasketService
    {
        #region Fields

        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public BasketService(IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        #endregion

        #region Methods

        public async Task AddItemToBasket(BasketItemToAddDto dto)
        {
            Basket basket = await _basketRepository.GetAsync(b => b.ClientBasketId == dto.ClientBasketId, new List<string> { nameof(Basket.BasketItems) });
            Product product = await _productRepository.GetAsync(p => p.Id == dto.ProductId);

            if (basket != null)
            {
                if (basket.BasketItems.Any(bi => bi.ProductId == dto.ProductId))
                {
                    BasketItem basketItem = basket.BasketItems.First(bi => bi.ProductId == dto.ProductId);
                    basketItem.Count += dto.Count;
                    basketItem.TotalAmount = basketItem.Count * product.Amount;
                }
                else
                {
                    basket.BasketItems.Add(new BasketItem
                    {
                        ProductId = dto.ProductId,
                        Count = dto.Count,
                        Amount = product.Amount,
                        TotalAmount = dto.Count * product.Amount
                    });
                }
            }
            else
            {
                basket = new Basket()
                {
                    ClientBasketId = dto.ClientBasketId,
                    BasketItems = new List<BasketItem>
                    {
                        new BasketItem()
                        {
                            ProductId = dto.ProductId,
                            Count = dto.Count,
                            Amount = product.Amount,
                            TotalAmount = dto.Count * product.Amount
                        }
                    },
                    TotalAmount = 0
                };

                await _basketRepository.Insert(basket);
            }

            basket.TotalAmount = basket.BasketItems.Sum(a => a.TotalAmount);
            await _basketRepository.SaveAsync();
        }

        public async Task Decrease(string clientBasketId, long productId)
        {
            Basket basket = await _basketRepository.GetAsync(b => b.ClientBasketId == clientBasketId, new List<string> { nameof(Basket.BasketItems) });
            Product product = await _productRepository.GetAsync(p => p.Id == productId);

            if (basket != null)
            {
                if (basket.BasketItems.Any(bi => bi.ProductId == productId))
                {
                    BasketItem basketItem = basket.BasketItems.First(bi => bi.ProductId == productId);

                    if (basketItem.Count > 1)
                    {
                        basketItem.Count -= 1;
                        basketItem.TotalAmount = basketItem.Count * product.Amount;
                    }
                    else
                    {
                        basket.BasketItems.Remove(basketItem);
                    }
                }
            }

            basket.TotalAmount = basket.BasketItems.Sum(a => a.TotalAmount);
            await _basketRepository.SaveAsync();
        }

        public async Task<Basket> GetBasket(string clientBasketId)
        {
            return await _basketRepository.GetAsync(b => b.ClientBasketId == clientBasketId, new List<string>
            {
                $"{nameof(Basket.BasketItems)}",
                $"{nameof(Basket.BasketItems)}.{nameof(BasketItem.Product)}"
            });
        }

        public async Task Increase(string clientBasketId, long productId)
        {
            Basket basket = await _basketRepository.GetAsync(b => b.ClientBasketId == clientBasketId, new List<string> { nameof(Basket.BasketItems) });
            Product product = await _productRepository.GetAsync(p => p.Id == productId);

            if (basket != null)
            {
                if (basket.BasketItems.Any(bi => bi.ProductId == productId))
                {
                    BasketItem basketItem = basket.BasketItems.First(bi => bi.ProductId == productId);

                    basketItem.Count += 1;
                    basketItem.TotalAmount = basketItem.Count * product.Amount;
                }
            }

            basket.TotalAmount = basket.BasketItems.Sum(a => a.TotalAmount);
            await _basketRepository.SaveAsync();
        }

        public async Task RemoveItemFromBasket(string clientBasketId, long basketItemId)
        {
            Basket basket = await _basketRepository.GetAsync(b => b.ClientBasketId == clientBasketId, new List<string> { nameof(Basket.BasketItems) });
            BasketItem basketItem = basket.BasketItems.FirstOrDefault(i => i.Id == basketItemId);

            if (basketItem != null)
            {
                basket.BasketItems.Remove(basketItem);
            }

            basket.TotalAmount = basket.BasketItems.Sum(a => a.TotalAmount);
            await _basketRepository.SaveAsync();
        }

        #endregion
    }
}
