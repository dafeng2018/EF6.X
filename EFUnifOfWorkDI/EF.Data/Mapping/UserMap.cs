using EF.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //table
            ToTable("Users");

            //key
            HasKey(t => t.ID);

            //properties
            Property(t => t.UserName).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.Password).IsRequired();
            Property(t => t.CreatedTime).IsRequired();
            Property(t => t.ModifiedTime).IsRequired();
            Property(t => t.IP);
        }
    }
}
