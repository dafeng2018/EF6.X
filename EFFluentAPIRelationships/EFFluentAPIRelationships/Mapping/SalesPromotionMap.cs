using EFFluentAPIRelationships.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships.Mapping
{
    public class SalesPromotionMap : EntityTypeConfiguration<SalesPromotion>
    {
        public SalesPromotionMap()
        {
            Property(p => p.SalesDiscount).HasPrecision(18, 4);
            HasMany(p => p.PromotionProductCatalog).WithMany(ca => ca.SalesPromotionHistory).Map(
                r =>
                {
                    //r => r.ToTable("ProductCatalogSalesPromotion");
                    r.ToTable("ProductCatalogSalesPromotion");
                    r.MapLeftKey("PromotionId");
                    r.MapRightKey("CatalogId");
                }
            );
        }
    }
}
