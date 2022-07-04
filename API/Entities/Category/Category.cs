using System.Collections.Generic;

namespace API.Entities
{
    public class Category : IEntity
    {
        #region Properties

        public long Id { get; set; }
        public string Title { get; set; }

        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
