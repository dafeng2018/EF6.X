using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships.Entities
{
    public class SalesPerson
    {
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime HiredDate { get; set; }
        public virtual ICollection<Order> CreatedOrders { get; set; }
        public virtual ICollection<Order> ApprovedOrders { get; set; }

    }
}
