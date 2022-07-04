using API.DataAccess;
using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.ApplicationServices
{
    public class ProductService : IProductService
    {
        #region Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteProduct(long id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<Product> GetProduct(long id)
        {
            return await _productRepository.GetAsync(p => p.Id == id, new List<string>() { nameof(Product.Category) });
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetAllAsync(null, new List<string>() { nameof(Product.Category) });
        }

        public async Task InsertProduct(Product product)
        {
            await _productRepository.Insert(product);
        }

        public async Task UpdateProduct(Product product)
        {
             await _productRepository.Update(product);
        }

        #endregion
    }
}
