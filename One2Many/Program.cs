using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One2Many
{
    class Program
    {
        static void Main(string[] args)
        {
            #region One2Many
            using (var db = new EFDbContext())
            {
                db.Database.Log = Console.Write;
                Customer customer = new Customer()
                {
                    Name = "Jacky",
                    Email = "Jack@EF.com",
                    CreatedTime = DateTime.Now,
                    ModifiedTime = DateTime.Now
                    //,
                    //Orders = new List<Order> {
                    //        new Order()
                    //        {
                    //            Quantity =12,
                    //            Price = 100,
                    //            CreatedTime = DateTime.Now,
                    //            ModifiedTime = DateTime.Now
                    //        },
                    //        new Order()
                    //        {
                    //            Quantity =120,
                    //            Price = 120,
                    //            CreatedTime = DateTime.Now,
                    //            ModifiedTime = DateTime.Now
                    //        },
                    //    }
                };
                db.Customers.Add(customer);
                db.SaveChanges();

            }
            #endregion

        }
    }
}
