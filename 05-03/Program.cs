using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 事务-1
            //using (var ctx = new EFDbContext())
            //{
            //    ctx.Database.Log = Console.WriteLine;
            //    ctx.Customers.Add(new Customer() {
            //        CreatedTime = DateTime.Now,
            //        ModifiedTime = DateTime.Now,
            //        Name = "Dafeng",
            //        Email = "email@email.com"
            //    });
            //    ctx.SaveChanges();
            //}
            #endregion
            #region 事务-2
            //using (var ctx = new EFDbContext())
            //{
            //    ctx.Database.Log = Console.WriteLine;
            //    ctx.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "update customers set email = 2 where id=@id", new SqlParameter("@id", 1));

            //}
            #endregion
            #region 事务-DbContextTransaction
            //using (var ctx = new EFDbContext())
            //{
            //    using (var transaction = ctx.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            var category = new Category
            //            {
            //                CategoryName = "Clothes"
            //            };
            //            ctx.Categories.Add(category);
            //            ctx.SaveChanges();
            //            throw new Exception("Custome Exception");

            //            Product product = new Product
            //            {
            //                ProductName = "Blue",
            //                CategoryID = category.CategoryID
            //            };
            //            ctx.Products.Add(product);
            //            ctx.SaveChanges();
            //            Console.WriteLine("Category and Product both saved");
            //            transaction.Commit();
            //        }
            //        catch(Exception exception)
            //        {
            //            transaction.Rollback();
            //            Console.WriteLine("Rool Backed {0}", exception);
            //        }
            //    }
            //}
            #endregion
            #region 事务-TransactionScope

            #endregion
        }
    }
}
