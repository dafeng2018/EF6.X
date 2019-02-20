using EFFluentAPIRelationships.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFluentAPIRelationships.Mapping
{
    public class SalesPersonMap : EntityTypeConfiguration<SalesPerson>
    {
        public SalesPersonMap()
        {
            HasKey(p => p.EmployeeID);//.Property(p => p.EmployeeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.Gender).IsRequired().HasMaxLength(1);
        }
    }
}
