using EFFluentAPIRelationships.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Database.SetInitializer<EFDbContext>(new EFDbInitializer());
            //using (EFDbContext db = new EFDbContext())
            //{
            //    var p = db.ProductCatalogs.Where(x => x.CatalogName.Length > 1);
            //    foreach (var item in p)
            //    {
            //        Console.WriteLine(item.CatalogName);
            //    }
            //}
            #endregion
            #region 复杂类型属性
            Customer newCustomer = new Customer() { IDCardNumber = "120104198106072518", CustomerName = "Alex", Gender = "M", PhoneNumber = "test" };
            Address customerAddress = new Address { Country = "China", Province = "Tianjin", City = "Tianjin", StreetAddress = "Crown Plaza", ZipCode = "300308" };
            newCustomer.Address = customerAddress;
            using (EFDbContext db = new EFDbContext())
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                Console.WriteLine(db.Customers.Where(c => c.IDCardNumber == "120104198106072518").Single().Address.Country);
            }

            #endregion
        }
    }
}
