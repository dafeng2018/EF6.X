using System.Collections.Generic;

namespace EFFluentAPIRelationships.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public virtual Order Order { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
        public decimal RetailPrice { get; set; }

    }
}