using static Client.StaticData;

namespace Client.Models
{
    public class ApiRequest
    {
        #region Properties

        public ApiType ApiType { get; set; } = ApiType.Get;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

        #endregion
    }
}
