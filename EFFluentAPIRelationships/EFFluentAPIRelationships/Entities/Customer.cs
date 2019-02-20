using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships.Entities
{
    public class Customer
    {
        public string IDCardNumber { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual BankAccount Account { get; set; }
    }
}
