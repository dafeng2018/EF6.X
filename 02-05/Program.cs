using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_05
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TPH
            //using (var db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    var bill = new BankAccount()
            //    {
            //        Owner = "Wang1",
            //        Number = "123",
            //        BankName = "Feng",
            //        Swift = "Platinum",

            //    };
            //    db.BillingDetails.Add(bill);
            //    db.SaveChanges();
            //}
            #endregion
            #region TPT
            //using (var db = new EFDbContext())
            //{
            //    db.Database.Log = Console.Write;
            //    var bill = new BankAccount()
            //    {
            //        Owner = "Wang1",
            //        Number = "123",
            //        BankName = "Feng",
            //        Swift = "Platinum",

            //    };
            //    db.BillingDetails.Add(bill);
            //    db.SaveChanges();
            //}
            #endregion
            #region EntitySplitting
            using (var db = new EFDbContext())
            {
                db.Database.Log = Console.Write;
                var employee = new Employee()
                {
                    CreateTime = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                    Name = "Feng",
                    PhoneNumber = "12300000",
                    Address = "Address"

                };
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            #endregion
            #region TableSpiltting
            using (var db = new EFDbContext())
            {
                db.Database.Log = Console.Write;
                var employee = db.Employees.ToList();
            }
            #endregion
        }
    }
}
