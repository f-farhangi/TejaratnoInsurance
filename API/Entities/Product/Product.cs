using System.Collections.Generic;

namespace API.Entities
{
    public class Product : IEntity
    {
        #region Properties

        public long Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; }

        #endregion
    }
}
