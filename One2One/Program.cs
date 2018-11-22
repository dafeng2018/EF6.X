using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One2One
{
    class Program
    {
        static void Main(string[] args)
        {
            #region One2One Mapping 1
            //using (var db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    Student student = new Student()
            //    {
            //        Name = "A",
            //        Contact = new StudentContact
            //        {
            //            ContactNumber = "A123"
            //        }
            //    };
            //    Student student1 = new Student()
            //    {
            //        Name = "B",

            //    };
            //    db.Students.Add(student1);
            //    db.SaveChanges();

            //}
            #endregion

            #region One2One Mapping 2
            using (var db = new EFDbContext())
            {
                db.Database.Log = Console.Write;
                Student student = new Student()
                {
                    Name = "B",
                    Contact = new StudentContact
                    {
                        ContactNumber = "B123"
                    }
                };
                db.Students.Add(student);
                db.SaveChanges();

            }
            #endregion

        }
    }
}
