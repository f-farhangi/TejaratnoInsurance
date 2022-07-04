using System.Collections.Generic;

namespace API.Entities
{
    public class Basket : IEntity
    {
        #region Properties

        public long Id { get; set; }
        public string ClientBasketId { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; }

        #endregion
    }
}
