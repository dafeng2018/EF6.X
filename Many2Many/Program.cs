using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many2Many
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Many2Many
            using (var db = new EFDbContext())
            {
                db.Database.Log = Console.Write;

                var student = new Student
                {
                    Name = "Jack",
                    Age = 26,
                    CreatedTime = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                    Courses = new List<Course>
                        {
                            new Course
                            {
                                Name = "C#1",
                                MaximumStrength = 12,
                                CreatedTime = DateTime.Now,
                                ModifiedTime = DateTime.Now
                            },
                                new Course{
                                Name = "EF2",
                                MaximumStrength = 120,
                                CreatedTime = DateTime.Now,
                                ModifiedTime = DateTime.Now
                            },
                        }
                };
                db.Students.Add(student);
                db.SaveChanges();

            }
            #endregion
        }
    }
}
