using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_05
{
    public class EmployeePhotoConfiguration : EntityTypeConfiguration<EmployeePhoto>
    {
        public EmployeePhotoConfiguration()
        {
            ToTable("Employees");
            HasKey(p => p.Id);
        }
    }
}
