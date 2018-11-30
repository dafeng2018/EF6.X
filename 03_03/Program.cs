using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AddData 
            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    Customer customer = new Customer()
            //    {
            //        Name = "Jacky",
            //        Email = "Jack@EF.com",
            //        CreatedTime = DateTime.Now,
            //        ModifiedTime = DateTime.Now
            //        ,
            //        Orders = new List<Order> {
            //                new Order()
            //                {
            //                    Quantity =12,
            //                    Price = 100,
            //                    CreatedTime = DateTime.Now,
            //                    ModifiedTime = DateTime.Now
            //                },
            //                new Order()
            //                {
            //                    Quantity =120,
            //                    Price = 120,
            //                    CreatedTime = DateTime.Now,
            //                    ModifiedTime = DateTime.Now
            //                },
            //            }
            //    };
            //    db.Customers.Add(customer);
            //    db.SaveChanges();
            //}
            #endregion
            #region 导航属性查询 
            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    //db.Orders.Where(c => c.Customer != null).ToList();
            //    db.Orders.Where(c => c.CustomerId != 0).ToList();
            //}
            #endregion
            #region Page 
            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    //db.Orders.Where(c => c.Customer != null).ToList();
            //    db.Orders.Where(c => c.CustomerId != 0).OrderBy(o => o.Id).Skip(10).Take(5).ToList();
            //}
            #endregion
            #region Null 
            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    //db.Orders.Where(c => c.Quantity == 12).ToList();
            //    var quantity = 12;
            //    db.Orders.Where(c => c.Quantity == quantity).ToList();
            //}
            #endregion

            #region Date 
            using (EFDbContext db = new EFDbContext())
            {
                db.Database.Log = Console.Write;
                db.Orders.Select(x=> new { Time = SqlFunctions.DateDiff("DAY",x.ModifiedTime,x.CreatedTime)}).ToList();
            }
            #endregion

        }
    }
}
