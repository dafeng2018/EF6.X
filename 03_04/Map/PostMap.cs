using _03_04.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace _03_04.Map
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            ToTable("Posts");
            HasKey(k => k.Id);
            Property(p => p.Title).IsRequired().HasColumnType("VARCHAR").HasMaxLength(100);
        }
    }
}