using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_04
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EFDbContext())
            {
                db.Database.Log = Console.Write;
                var blog = new Blog
                {
                    Name = "Blog",

                };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }
    }
}
