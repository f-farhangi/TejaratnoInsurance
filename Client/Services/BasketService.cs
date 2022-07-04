using Client.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Services
{
    public class BasketService : BaseService, IBasketService
    {
        #region Fields

        private readonly IHttpClientFactory _httpClient;

        #endregion

        #region Constructor

        public BasketService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<T> AddItemToBasketAsync<T>(BasketItemToAddDto basketItem)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Post,
                Data = basketItem,
                Url = StaticData.BasketAPIBase
            });
        }

        public async Task<T> DecreaseItem<T>(OperationalBasketItemDto basketItem)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Post,
                Data = basketItem,
                Url = StaticData.BasketAPIBase + "Decrease"
            });
        }

        public async Task<T> GetBasketByIdAsync<T>(string basketId)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Get,
                Data = null,
                Url = StaticData.BasketAPIBase + basketId
            });
        }

        public async Task<T> IncreaseItem<T>(OperationalBasketItemDto basketItem)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Post,
                Data = basketItem,
                Url = StaticData.BasketAPIBase + "Increase"
            });
        }

        public async Task<T> RemoveItemFromBasketAsync<T>(BasketItemToRemoveDto basketItem)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = null,
                ApiType = StaticData.ApiType.Delete,
                Data = basketItem,
                Url = StaticData.BasketAPIBase
            });
        }

        #endregion
    }
}
