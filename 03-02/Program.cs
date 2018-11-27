using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_02
{
    internal class Program
    {
        private static void Main(string[] args)
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
            #region Lazy Loading
            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    Customer customer = db.Customers.FirstOrDefault();
            //    var order = customer.Orders;
            //}
            #endregion
            #region Eager Loading
            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    Customer customer = db.Customers.Include(o=>o.Orders).FirstOrDefault();
            //}
            #endregion
            #region Explicitly Loading
            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    Customer customer = db.Customers.FirstOrDefault();
            //    var order = db.Entry(customer).Collection(o =>o.Orders).Query().ToList();
            //}
            #endregion
            #region Query1 - 利用SqlQuery必须返回所有列
            using (EFDbContext db = new EFDbContext())
            {
                //方法实体查询实体在数据库上，实体不会被上下文跟踪
                //db.Database.Log = Console.Write;
                //var customers = db.Database.SqlQuery<Customer>("select * from dbo.customers").ToList();
                //customers.Last().Email = "query1";
                //db.SaveChanges();
            }
            #endregion
            #region Query2
            using (EFDbContext db = new EFDbContext())
            {
                //方法实体查询在上下文的实体集合，实体会被上下文跟踪
                db.Database.Log = Console.Write;
                List<Customer> customers = db.Customers.SqlQuery("select * from dbo.customers").ToList();
                customers.Last().Email = "query2";
                db.SaveChanges();

            }
            #endregion
        }
    }
}
