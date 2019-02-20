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
    public class AddressMap : ComplexTypeConfiguration<Address>
    {
        public AddressMap()
        {
            Property(a => a.Country).HasColumnName("Country").HasMaxLength(100);
            Property(a => a.Province).HasColumnName("Province").HasMaxLength(100);
            Property(a => a.City).HasColumnName("City").HasMaxLength(100);
            Property(a => a.StreetAddress).HasColumnName("StreetAddress").HasMaxLength(500);
            Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(6);
        }
    }
}
