using _03_04.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace _03_04.Map
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            ToTable("Blogs");
            HasKey(k => k.Id);
            Property(p => p.Url).IsRequired().HasColumnType("VARCHAR").HasMaxLength(100);
            Property(p => p._Tags).HasColumnName("Tags");
            Property(p => p._Owner).HasColumnName("Owner");
            Ignore(p => p.Owner);
            Ignore(p => p.Tags);
            HasMany(p => p.Posts).WithRequired(p => p.Blog).HasForeignKey(k => k.BlogId).WillCascadeOnDelete(true);
        }
    }
}