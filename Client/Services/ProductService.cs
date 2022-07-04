using Client.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ProductService : BaseService, IProductService
    {
        #region Fields

        private readonly IHttpClientFactory _httpClient;

        #endregion

        #region Constructor

        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Post,
                Data = productDto,
                Url = StaticData.ProductAPIBase
            });
        }

        public async Task<T> DeleteProductsAsync<T>(long productId)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Delete,
                Data = null,
                Url = StaticData.ProductAPIBase + productId
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Get,
                Data = null,
                Url = StaticData.ProductAPIBase
            });
        }

        public async Task<T> GetProductByIdAsync<T>(long productId)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Get,
                Data = null,
                Url = StaticData.ProductAPIBase + productId
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Put,
                Data = productDto,
                Url = StaticData.ProductAPIBase + productDto.Id
            });
        }

        #endregion
    }
}
