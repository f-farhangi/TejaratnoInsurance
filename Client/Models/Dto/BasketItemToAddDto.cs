namespace Client.Models
{
    public class BasketItemToAddDto
    {
        #region Properties

        public string ClientBasketId { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }

        #endregion
    }
}
