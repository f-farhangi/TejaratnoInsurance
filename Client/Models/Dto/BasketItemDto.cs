namespace Client.Models
{
    public class BasketItemDto
    {
        #region Properties

        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }

        #endregion
    }
}
