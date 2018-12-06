using MVC_Repository.Domain.Entities;
using System.Data.Entity;

namespace MVC_Repository.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<EFDbContext>(new EFDbInitializer());
            //Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysUserInfo> SysUserInfos { get; set; }
        public DbSet<SysUserRole> SysUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new OrderMap());
        }
    }
}
