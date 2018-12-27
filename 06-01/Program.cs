using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01 - Add User
            //using (var ctx = new EFDbContext())
            //{
            //    ctx.Database.Log = Console.WriteLine;
            //    Student s = new Student
            //    {
            //        Name = "Dafeng",
            //        Age = 200,
            //        CreatedTime = DateTime.Now,
            //        ModifiedTime = DateTime.Now
            //    };

            //    ctx.Students.Add(s);
            //    ctx.SaveChanges();
            //}
            #endregion
            #region 02 - concurrent 
            //using (var ctx = new EFDbContext())
            //{
            //    ctx.Database.Log = Console.WriteLine;
            //    using (var ctx1 = new EFDbContext())
            //    {
            //        ctx1.Database.Log = Console.WriteLine;
            //        var id = 1;
            //        var s1 = ctx.Students.FirstOrDefault(d => d.Id == id);
            //        var s2 = ctx1.Students.FirstOrDefault(d => d.Id == id);
            //        s1.Name = "dafeng - 1";
            //        ctx.SaveChanges();

            //        s2.Name = "dafeng - 2";
            //        try
            //        {
            //            ctx1.SaveChanges();

            //        }
            //        catch (DbUpdateConcurrencyException ex)
            //        {

            //            ex.Entries.Single().Reload();
            //            ctx1.SaveChanges();
            //        }
            //    }
            //}
            #endregion
            #region 03 - concurrent 
            //using (var ctx = new EFDbContext())
            //{
            //    //ctx.Database.Log = Console.WriteLine;
            //    using (var ctx1 = new EFDbContext())
            //    {
            //        //ctx1.Database.Log = Console.WriteLine;
            //        var id = 1;
            //        var s1 = ctx.Students.FirstOrDefault(d => d.Id == id);
            //        var s2 = ctx1.Students.FirstOrDefault(d => d.Id == id);
            //        s1.Name = "dafeng - 1";
            //        ctx.SaveChanges();

            //        s2.Name = "dafeng - 2";
            //        try
            //        {
            //            ctx1.SaveChanges();
            //        }
            //        catch (DbUpdateConcurrencyException ex)
            //        {
            //            var tracking = ex.Entries.Single();
            //            var original = (Student)tracking.OriginalValues.ToObject();
            //            var database = (Student)tracking.GetDatabaseValues().ToObject();
            //            var current = (Student)tracking.CurrentValues.ToObject();


            //            Console.WriteLine("原始值({" + original.Id + "},{" + original.Name + "},{" + original.Age + "})");
            //            Console.WriteLine("-----------------------------");
            //            //var dbValues = @"数据库值：({database.Id},{database.Name},{database.Age})";
            //            Console.WriteLine("数据库值：({" + database.Id + "},{ " + database.Name + "},{ " + database.Age + "})");
            //            Console.WriteLine("-----------------------------");
            //            //var update = $"更新值：({current.Id},{current.Name},{current.Age})";
            //            Console.WriteLine("更新值：({ " + current.Id + "},{" + current.Name + "},{" + current.Age + "})");
            //            Console.WriteLine("-----------------------------");
            //            tracking.OriginalValues.SetValues(database);
            //            ctx1.SaveChanges();
            //        }
            //    }
            //}
            #endregion
            #region 04 - 客户端获胜 
            //using (var ctx = new EFDbContext())
            //{
            //    //ctx.Database.Log = Console.WriteLine;
            //    using (var ctx1 = new EFDbContext())
            //    {
            //        //ctx1.Database.Log = Console.WriteLine;
            //        var id = 1;
            //        var s1 = ctx.Students.FirstOrDefault(d => d.Id == id);
            //        var s2 = ctx1.Students.FirstOrDefault(d => d.Id == id);
            //        s1.Name = "dafeng - 1";
            //        ctx.SaveChanges();

            //        s2.Name = "dafeng - 2";
            //        try
            //        {
            //            ctx1.SaveChanges();
            //        }
            //        catch (DbUpdateConcurrencyException ex)
            //        {
            //            var tracking = ex.Entries.Single();
            //            var original = (Student)tracking.OriginalValues.ToObject();
            //            var database = (Student)tracking.GetDatabaseValues().ToObject();
            //            var current = (Student)tracking.CurrentValues.ToObject();


            //            Console.WriteLine("原始值({" + original.Id + "},{" + original.Name + "},{" + original.Age + "})");
            //            Console.WriteLine("-----------------------------");
            //            //var dbValues = @"数据库值：({database.Id},{database.Name},{database.Age})";
            //            Console.WriteLine("数据库值：({" + database.Id + "},{ " + database.Name + "},{ " + database.Age + "})");
            //            Console.WriteLine("-----------------------------");
            //            //var update = $"更新值：({current.Id},{current.Name},{current.Age})";
            //            Console.WriteLine("更新值：({ " + current.Id + "},{" + current.Name + "},{" + current.Age + "})");
            //            Console.WriteLine("-----------------------------");
            //            tracking.OriginalValues.SetValues(database);
            //            ctx1.SaveChanges();
            //        }
            //    }
            //}
            #endregion
            #region 05 - 数据库获胜 
            //using (var ctx = new EFDbContext())
            //{
            //    //ctx.Database.Log = Console.WriteLine;
            //    using (var ctx1 = new EFDbContext())
            //    {
            //        //ctx1.Database.Log = Console.WriteLine;
            //        var id = 1;
            //        var s1 = ctx.Students.FirstOrDefault(d => d.Id == id);
            //        var s2 = ctx1.Students.FirstOrDefault(d => d.Id == id);
            //        s1.Name = "dafeng - 1";
            //        ctx.SaveChanges();

            //        s2.Name = "dafeng - 2";
            //        try
            //        {
            //            ctx1.SaveChanges();
            //        }
            //        catch (DbUpdateConcurrencyException ex)
            //        {
            //            return;
            //        }
            //    }
            //}
            #endregion
            #region 06 - 客户端和数据库合并获胜 https://github.com/striveCj/StudyCode
            //using (var ctx = new EFDbContext())
            //{
            //    //ctx.Database.Log = Console.WriteLine;
            //    using (var ctx1 = new EFDbContext())
            //    {
            //        //ctx1.Database.Log = Console.WriteLine;
            //        var id = 1;
            //        var s1 = ctx.Students.FirstOrDefault(d => d.Id == id);
            //        var s2 = ctx1.Students.FirstOrDefault(d => d.Id == id);
            //        s1.Name = "dafeng - 1";
            //        s1.Age = 25;
            //        ctx.SaveChanges();

            //        s2.Name = "dafeng - 2";
            //        s2.Age = 26;
            //        try
            //        {
            //            ctx1.SaveChanges();
            //        }
            //        catch (DbUpdateConcurrencyException ex)
            //        {
            //            Retry(ctx1, handleDbUpdateConcurrencyException: exception =>
            //            {
            //                exception = (ex as DbUpdateConcurrencyException).Entries;
            //                var tracking = exception.Single();
            //                var databaseValues = tracking.GetDatabaseValues();
            //                var originalValues = tracking.OriginalValues.Clone();
            //                var original = (Student)tracking.OriginalValues.ToObject();
            //                var database = (Student)tracking.GetDatabaseValues().ToObject();
            //                var current = (Student)tracking.CurrentValues.ToObject();

            //                tracking.OriginalValues.SetValues(databaseValues);
            //                databaseValues.PropertyNames.Where(property => !object.Equals(originalValues[property], databaseValues[property])).ToList().ForEach(property => tracking.Property(property).IsModified = false);
            //            });
            //        }
            //    }
            //}
            #endregion

        }
        static int Retry(EFDbContext context, Action<IEnumerable<DbEntityEntry>> handleDbUpdateConcurrencyException, int retryCount = 3)
        {
            for (int retry = 1; retry < retryCount; retry++)
            {
                try
                {
                    return context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    handleDbUpdateConcurrencyException(exception.Entries);
                }
            }
            return context.SaveChanges();
        }

    }
}
