using System.Data.Entity;

namespace _02_02_Convention

{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=ConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
        }
        public DbSet<MyConvention> MyConventions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //method-1
            //modelBuilder.Properties().Where(p => p.Name == "Id").Configure(p => p.IsKey());

            //method-2
            modelBuilder.Conventions.Add<CustomerKeyConvention>();
        }
    }
}
