using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Add-1
            //using (var db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    Customer customer = new Customer()
            //    {
            //        Name = "Jacky",
            //        Email = "Jack@EF.com",
            //    };
            //    db.Customers.Add(customer);
            //    db.SaveChanges();

            //}
            #endregion
            #region Add-2
            //using (var db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    Customer customer = new Customer()
            //    {
            //        Name = "Jacky2",
            //        Email = "Jack2@EF.com",
            //    };
            //    db.Entry(customer).State = System.Data.Entity.EntityState.Added;
            //    db.SaveChanges();

            //}
            #endregion
            #region Unchanged-1
            //using (var db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    Customer customer = new Customer()
            //    {
            //        Name = "Jacky3",
            //        Email = "Jack3@EF.com",
            //    };
            //    db.Customers.Attach(customer);
            //    db.Entry(customer).State = System.Data.Entity.EntityState.Unchanged;
            //    db.SaveChanges();

            //}
            #endregion
            #region Unchanged-2
            //using (var db = new EFDbContext())
            //{
            //    var c = TestState();
            //    Console.WriteLine(db.Entry(c).State);
            //    db.Customers.Attach(c);
            //    //调用Attach方法变成了Unchanged状态。Unchanged状态会被SaveChanges方法忽略掉，不会有任何sql发送到数据库。
            //    db.SaveChanges();
            //}
            #endregion
            #region Modified-1
            //using (var db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    var u = db.Customers.Where(c => c.Id == 1).FirstOrDefault();
            //    u.Name = "EF - Modified -1";
            //    db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            //    db.SaveChanges();

            //}
            #endregion
            #region Page
            using (var db = new EFDbContext())
            {
                db.Database.Log = Console.Write;
                //for (int i = 0; i < 100; i++)
                //{
                //    Customer customer = new Customer()
                //    {
                //        Name = "Jacky " + i,
                //        Email = "Jack " + i + "@EF.com",
                //    };
                //    db.Customers.Add(customer);
                //}
                //db.SaveChanges();
                var page = db.Customers.Where(c=>c.Id>10).OrderByDescending(d=>d.Id).Take(10).Skip(3).ToList();
                foreach (var item in page)
                {
                    Console.WriteLine(item.Id +" "+item.Name);
                }

            }
            #endregion
        }
        static Customer TestState()
        {
            using (var db = new EFDbContext())
            {
                var u = db.Customers.Where(c => c.Id == 1).FirstOrDefault();
                Console.WriteLine("TestState - " + db.Entry(u).State);
                return u;
            }
        }
    }
}
