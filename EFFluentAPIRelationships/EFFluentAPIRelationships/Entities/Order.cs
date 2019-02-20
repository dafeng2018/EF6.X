using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual SalesPerson CreatedBy { get; set; }
        public virtual SalesPerson ApprovedBy { get; set; }
    }
}
