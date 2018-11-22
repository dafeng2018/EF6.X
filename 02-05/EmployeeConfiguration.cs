using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_05
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            //Map(m =>
            //{
            //    m.Properties(p => new
            //    {
            //        p.EmployeeId,
            //        p.Name,
            //        p.CreateTime,
            //        p.ModifiedTime
            //    });
            //    m.ToTable("Employees");
            //}).Map(m =>
            //{
            //    m.Properties(p => new
            //    {
            //        p.PhoneNumber,
            //        p.Address
            //    });
            //    m.ToTable("EmployeeDetails");
            //});
            ToTable("Employees");
            HasKey(p => p.EmployeeId);

            HasRequired(p => p.Photo).WithRequiredPrincipal(p => p.Employee);
        }
    }
}
