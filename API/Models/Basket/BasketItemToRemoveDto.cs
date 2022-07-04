namespace API.Models
{
    public class BasketItemToRemoveDto
    {
        #region Properties

        public string ClientBasketId { get; set; }
        public long BasketItemId { get; set; }

        #endregion
    }
}
