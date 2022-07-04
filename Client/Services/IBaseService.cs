using Client.Models;
using System;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IBaseService : IDisposable
    {
        #region Methods

        Task<T> SendAsync<T>(ApiRequest apiRequest);

        #endregion
    }
}
