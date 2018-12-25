using System.Collections.Generic;

namespace _05_03
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
