using System;
using System.Collections.Generic;

namespace EFFluentAPIRelationships.Entities
{
    public class SalesPromotion
    {
        public int SalesPromotionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalesDiscount { get; set; }
        public virtual ICollection<ProductCatalog> PromotionProductCatalog { get; set; }
    }
}