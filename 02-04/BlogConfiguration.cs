using System.Data.Entity.ModelConfiguration;

namespace _02_04
{
    public class BlogConfiguration : EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {
            //设置主键
            //默认约定：整型键：Identity。
            //重写约定：使用Property(t => t.属性名).HasDatabaseGeneratedOption(DatabaseGeneratedOption)
            //DatabaseGeneratedOption枚举包括三个成员：
            //(1) None：数据库不生成值
            //(2) Identity：当插入行时，数据库生成值
            //(3) Computed：当插入或更新行时，数据库生成值
            //整型默认是Identity，数据库生成值，自动增长，如果不想数据库自动生成值，使用DatabaseGeneratedOption.None。
            //Guid类型作为主键时，要显示配置为DatabaseGeneratedOption.Identity
            HasKey(c => c.Id).Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasKey(k => new { Id = k.Id, BlogId = k.BlogId });
            //decimal ->18,2
            Property(p => p.Price).HasPrecision(18, 4);
            Property(p => p.Name).HasColumnType("VARCHAR").HasMaxLength(500).IsRequired();
            Property(p => p.CreatedTime).HasColumnType("DATETIME2");
            Property(p => p.Double).IsOptional();


        }
    }
}
