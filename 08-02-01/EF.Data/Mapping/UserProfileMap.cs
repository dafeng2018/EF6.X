using EF.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Mapping
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            //table
            ToTable("UserProfiles");

            //key
            HasKey(t => t.ID);

            //properties           
            Property(t => t.FirstName).IsRequired().HasMaxLength(100);
            Property(t => t.LastName).HasMaxLength(100);
            Property(t => t.Address);
            Property(t => t.CreatedTime).IsRequired();
            Property(t => t.ModifiedTime).IsRequired();
            Property(t => t.IP);

            //relation          
            HasRequired(t => t.User).WithRequiredDependent(u => u.UserProfile);
        }
    }
}
