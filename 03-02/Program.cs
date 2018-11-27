using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //using (EFDbContext db = new EFDbContext())
            //{
            //方法实体查询实体在数据库上，实体不会被上下文跟踪
            //db.Database.Log = Console.Write;
            //var customers = db.Database.SqlQuery<Customer>("select * from dbo.customers").ToList();
            //customers.Last().Email = "query1";
            //db.SaveChanges();
            //}
            #endregion
            #region Query2
            //using (EFDbContext db = new EFDbContext())
            //{
            //    //方法实体查询在上下文的实体集合，实体会被上下文跟踪
            //    db.Database.Log = Console.Write;
            //    List<Customer> customers = db.Customers.SqlQuery("select * from dbo.customers").ToList();
            //    customers.Last().Email = "query2";
            //    db.SaveChanges();

            //}
            #endregion
            #region Query3
            //ctx.Database.SqlQuery<TEntity>() - 支持返回单挑记录
            //ctx.Set<TEntity>().SqlQuery() - 不支持返回单挑记录

            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    //var c1 = db.Customers.SqlQuery("select count(*) from dbo.customers").ToList();
            //    var c2 = db.Database.SqlQuery<int>("select count(*) from dbo.customers").ToList();

            //}

            #endregion
            #region Query4 - 参数化SQL实现
            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    int Id = 2;
            //    var parameters = new SqlParameter[]
            //    {
            //        new SqlParameter(){ ParameterName = "@Id",SqlDbType = System.Data.SqlDbType.Int,Value = Id}
            //    };
            //    var customer = db.Database.SqlQuery<Customer>("select * from customers where id=@Id", parameters).ToList();

            //}
            #endregion
            #region Query5 - ExecuteSqlCommand
            //using (EFDbContext db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    string sql = "insert into Customers(Name,Email,CreatedTime,ModifiedTime) Values(@Name,@Email,@createdTime,@ModifiedTime)";
            //    var parameterList = new List<SqlParameter>
            //    {
            //        new SqlParameter("@Name","ExecuteSqlCommand"),
            //        new SqlParameter("@createdTime",DateTime.Now),
            //        new SqlParameter("@ModifiedTime",DateTime.Now),
            //        new SqlParameter("@EMail","ExecuteSqlCommand@ExecuteSqlCommand.com")
            //    };
            //    var parameters = parameterList.ToArray();
            //    db.Database.ExecuteSqlCommand(sql, parameters);
            //}
            #endregion


        }


    }
}
