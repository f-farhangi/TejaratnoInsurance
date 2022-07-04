using Client.Models;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IBasketService : IBaseService
    {
        #region Methods

        Task<T> GetBasketByIdAsync<T>(string basketId);
        Task<T> AddItemToBasketAsync<T>(BasketItemToAddDto basketItem);
        Task<T> RemoveItemFromBasketAsync<T>(BasketItemToRemoveDto basketItem);
        Task<T> IncreaseItem<T>(OperationalBasketItemDto basketItem);
        Task<T> DecreaseItem<T>(OperationalBasketItemDto basketItem);

        #endregion

    }
}
