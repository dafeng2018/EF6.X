using System.Data.Entity.ModelConfiguration;

namespace One2Many
{
    internal class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            //HasRequired(t => t.Customer).WithMany(t => t.Orders).HasForeignKey(t => t.CustomerId);
        }
    }
}