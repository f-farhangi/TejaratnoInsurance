namespace Client.Models
{
    public class ProductDto
    {
        #region Properties

        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        #endregion
    }
}
