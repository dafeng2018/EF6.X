using System.Data.Entity;

namespace _02_04
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=ConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlogConfiguration());
            modelBuilder.ComplexType<Address>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
