using EFFluentAPIRelationships.Entities;
using EFFluentAPIRelationships.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=ConnectionString")
        {
            Database.SetInitializer<EFDbContext>(new EFDbInitializer());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCatalog> ProductCatalogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<SalesPromotion> SalesPromotions { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new SalesPersonMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new SalesPromotionMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
