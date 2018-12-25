
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_03
{
   public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            HasMany(p => p.Products).WithRequired(c => c.Category).HasForeignKey(k => k.CategoryID);
        }
    }
}
