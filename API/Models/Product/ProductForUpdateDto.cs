
namespace API.Models
{
    public class ProductForUpdateDto
    {
        #region Properties

        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        #endregion
    }
}
