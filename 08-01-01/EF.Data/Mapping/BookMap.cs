using EF.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            //table
            ToTable("Books");

            //key
            HasKey(t => t.ID);

            //property
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Title).IsRequired().HasMaxLength(200);
            Property(t => t.Author).IsRequired().HasMaxLength(200);
            Property(t => t.ISBN).IsRequired().HasMaxLength(200);
            Property(t => t.Published).IsRequired();
            Property(t => t.Url).IsRequired();
        }

    }
}
