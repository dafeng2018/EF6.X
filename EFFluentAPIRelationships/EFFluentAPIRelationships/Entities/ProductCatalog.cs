using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships.Entities
{
    public class ProductCatalog
    {
        public int ProductCatalogId { get; set; }
        public string CatalogName { get; set; }
        public string Manufactory { get; set; }
        public decimal ListPrice { get; set; }
        public decimal NetPrice { get; set; }

        public virtual ICollection<SalesPromotion> SalesPromotionHistory { get; set; }
    }
}
