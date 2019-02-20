
using EFFluentAPIRelationships.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            HasMany(o => o.OrderItems).WithRequired(i => i.Order).Map(m => m.MapKey("OrderID"));
            HasOptional(p => p.CreatedBy).WithMany(o => o.CreatedOrders).Map(m => m.MapKey("CreatedBy"));
            HasOptional(p => p.ApprovedBy).WithMany(o => o.ApprovedOrders).Map(m => m.MapKey("ApprovedBy"));
        }
    }
}
