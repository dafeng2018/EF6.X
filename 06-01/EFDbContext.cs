using System.Data.Entity;

namespace _06_01
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=ConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
            //Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(p => p.Name).IsConcurrencyToken();
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new OrderMap());
            //modelBuilder.Configurations.Add(new CustomerMap());
        }
    }
}
