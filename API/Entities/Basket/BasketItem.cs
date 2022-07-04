namespace API.Entities
{
    public class BasketItem : IEntity
    {
        #region Property

        public long Id { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }


        public long BasketId { get; set; }
        public Basket Basket { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        #endregion
    }
}
