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
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(k => k.IDCardNumber).Property(k => k.IDCardNumber).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.IDCardNumber).HasMaxLength(20);
            Property(c => c.CustomerName).IsRequired().HasMaxLength(50);
            Property(c => c.Gender).IsRequired().HasMaxLength(1);
            Property(c => c.PhoneNumber).HasMaxLength(20);
            //如果你选择WithOptionalDependent则代表Customer表中有一个外键指向BankAccount表的主键，如果你选择WithOptionalPrincipal则相反，BankAccount拥有指向Customer表的外键。
            HasOptional(c => c.Account).WithOptionalDependent(c => c.Customer);
        }
    }
}
