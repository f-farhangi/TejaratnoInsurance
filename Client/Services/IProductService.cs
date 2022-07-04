using Client.Models;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IProductService : IBaseService
    {
        #region Methods

        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(long productId);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductsAsync<T>(long productId);

        #endregion
    }
}
