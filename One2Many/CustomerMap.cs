using System.Data.Entity.ModelConfiguration;

namespace One2Many
{
    internal class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            Property(t => t.Email).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            //HasMany(t => t.Orders).WithRequired(t => t.Customer).HasForeignKey(t => t.CustomerId).WillCascadeOnDelete();
            HasMany(t => t.Orders).WithRequired(t => t.Customer).WillCascadeOnDelete();
        }
    }
}