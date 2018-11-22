using System.Data.Entity;

namespace _02_05
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=ConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
        }
        public DbSet<BillingDetail> BillingDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region TPH
            //modelBuilder.Entity<BillingDetail>().Map<BankAccount>(m => m.Requires("BillingTypeDetail").HasValue(1));
            //modelBuilder.Entity<BillingDetail>().Map<CreditCard>(m => m.Requires("BillingTypeDetail").HasValue(2));
            #endregion

            #region TPT
            //modelBuilder.Entity<BankAccount>().ToTable("BankAccount");
            //modelBuilder.Entity<CreditCard>().ToTable("CreditCard");
            #endregion

            #region EntitySplitting
            //modelBuilder.Configurations.Add(new EmployeeConfiguration());
            #endregion
            #region TableSpiltting
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new EmployeePhotoConfiguration());
            #endregion

        }
    }
}
