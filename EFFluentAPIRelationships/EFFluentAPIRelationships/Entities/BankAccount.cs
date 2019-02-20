using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships.Entities
{
    public class BankAccount
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
