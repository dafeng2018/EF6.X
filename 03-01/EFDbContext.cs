using System.Data.Entity;

namespace _03_01
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=ConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
