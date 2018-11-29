using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Z.EntityFramework.Plus;

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
            #region Update - 上下文只能存在主键等于1的一个对象，AsNoTracking 取消跟踪
            //using (EFDbContext db = new EFDbContext())
            //{
            //    //db.Database.Log = Console.Write;
            //    var customer = GetCustomer();
            //    var dbCustomer = db.Customers.AsNoTracking().Where(p => p.Id == customer.Id).FirstOrDefault();
            //    if (dbCustomer != null)
            //    {
            //        db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            //        if (db.SaveChanges() > 0)
            //        {
            //            Console.WriteLine("-done-");
            //        }
            //        else
            //        {
            //            Console.WriteLine("-fail-");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("dbCustomer is null");
            //    }
            //}
            #endregion
            #region Update - 更新部分属性
            //using (EFDbContext db = new EFDbContext())
            //{
            //    //db.Database.Log = Console.Write;
            //    var customer = GetCustomer2();
            //    #region 更新部分属性1
            //    //var dbCustomer = db.Customers.Where(p => p.Id == customer.Id).FirstOrDefault();
            //    //if (dbCustomer != null)
            //    //{
            //    //    dbCustomer.Email = customer.Email;
            //    //    dbCustomer.ModifiedTime = DateTime.Now;
            //    //    dbCustomer.Name = customer.Name;
            //    //    if (db.SaveChanges() > 0)
            //    //    {
            //    //        Console.WriteLine("-done-");
            //    //    }
            //    //    else
            //    //    {
            //    //        Console.WriteLine("-fail-");
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("dbCustomer is null");
            //    //}
            //    #endregion


            //    #region 更新部分属性2
            //    //db.Customers.Attach(customer);
            //    //db.Entry(customer).Property(p => p.Email).IsModified = true;
            //    //db.Entry(customer).Property(p => p.ModifiedTime).IsModified = true;
            //    //db.Entry(customer).Property(p => p.Name).IsModified = true;
            //    //if (db.SaveChanges() > 0)
            //    //{
            //    //    Console.WriteLine("-done-");
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("-fail-");
            //    //}
            //    #endregion
            //    #region 更新全部属性
            //    customer = GetCustomer();
            //    var dbCustomer = db.Customers.Where(p => p.Id == customer.Id).FirstOrDefault();
            //    if (dbCustomer != null)
            //    {
            //        db.Entry(dbCustomer).CurrentValues.SetValues(customer);
            //        if (db.SaveChanges() > 0)
            //        {
            //            Console.WriteLine("-done-");
            //        }
            //        else
            //        {
            //            Console.WriteLine("-fail-");
            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("dbCustomer is null");
            //    }
            //}
            #endregion
            #region 批量更新EntityFramework-Plus
            using (EFDbContext db = new EFDbContext())
            {
                db.Database.Log = Console.Write;
                var customer = db.Customers.Where(d => d.Email.Contains("@")).Update(d => new Customer() { Email = "EntityFramework-Plus@EntityFramework-Plus.com" });
                db.SaveChanges();
            }


            #endregion


        }
        static Customer GetCustomer()
        {
            var customer = new Customer()
            {
                Id = 1,
                CreatedTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                Email = "Update - EMail",
                Name = " - Update - "
            };
            return customer;
        }
        static Customer GetCustomer2()
        {
            var customer = new Customer()
            {
                Id = 1,
                ModifiedTime = DateTime.Now,
                Email = "Update - EMail",
                Name = " - Update - "
            };
            return customer;
        }

    }
}
