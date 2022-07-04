using Client.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        #region Fields

        private readonly IHttpClientFactory _httpClient;

        #endregion

        #region Constructor

        public CategoryService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Post,
                Data = categoryDto,
                Url = StaticData.CategoryAPIBase
            });
        }

        public async Task<T> DeleteCategorysAsync<T>(long categoryId)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Delete,
                Data = null,
                Url = StaticData.CategoryAPIBase + categoryId
            });
        }

        public async Task<T> GetAllCategoriesAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Get,
                Data = null,
                Url = StaticData.CategoryAPIBase
            });
        }

        public async Task<T> GetCategoryByIdAsync<T>(long categoryId)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Get,
                Data = null,
                Url = StaticData.CategoryAPIBase + categoryId
            });
        }

        public async Task<T> UpdateCategoryAsync<T>(CategoryDto categoryDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Put,
                Data = categoryDto,
                Url = StaticData.CategoryAPIBase + categoryDto.Id
            });
        }

        #endregion
    }
}
