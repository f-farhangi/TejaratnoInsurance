using System.Collections.Generic;

namespace API.Models
{
    public class BasketDto
    {
        #region Properties

        public long Id { get; set; }
        public string ClientBasketId { get; set; }
        public decimal TotalAmount { get; set; }

        public List<BasketItemDto> BasketItems { get; set; }

        #endregion
    }
}
