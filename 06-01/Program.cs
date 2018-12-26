using System;
using System.Collections.Generic;
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
            using (var ctx = new EFDbContext())
            {
                ctx.Database.Log = Console.WriteLine;
                using (var ctx1 = new EFDbContext())
                {
                    ctx1.Database.Log = Console.WriteLine;
                    var id = 1;
                    var s1 = ctx.Students.FirstOrDefault(d => d.Id == id);
                    var s2 = ctx1.Students.FirstOrDefault(d => d.Id == id);
                    s1.Name = "dafeng - 1";
                    ctx.SaveChanges();

                    s2.Name = "dafeng - 2";
                    ctx1.SaveChanges();
                }

            }
            #endregion

        }
    }
}
