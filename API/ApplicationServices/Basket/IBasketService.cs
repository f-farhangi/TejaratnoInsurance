using API.Entities;
using API.Models;
using System.Threading.Tasks;

namespace API.ApplicationServices
{
    public interface IBasketService
    {
        #region Methods

        Task<Basket> GetBasket(string clientBasketId);
        Task AddItemToBasket(BasketItemToAddDto dto);
        Task RemoveItemFromBasket(string clientBasketId, long basketItemId);
        Task Increase(string clientBasketId, long productId);
        Task Decrease(string clientBasketId, long productId);

        #endregion
    }
}
