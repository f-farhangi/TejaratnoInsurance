namespace Client
{
    public static class StaticData
    {
        #region Properties

        public static string CategoryAPIBase { get; set; }
        public static string ProductAPIBase { get; set; }
        public static string BasketAPIBase { get; set; }

        public enum ApiType
        {
            Get,
            Post,
            Put,
            Delete
        }

        #endregion
    }
}
