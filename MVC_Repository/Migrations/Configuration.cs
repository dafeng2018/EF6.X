namespace MVC_Repository.Migrations
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Repository.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_Repository.Domain.Concrete.EFDbContext context)
        {
            //var users = new List<SysUserInfo>()
            //{
            //    new SysUserInfo()
            //    {
            //        //Id = 1,
            //        Name="Admin",
            //        Password="123456",
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        Email="Alice@qq.com"
            //    },
            //    new SysUserInfo()
            //    {
            //        //Id = 2,
            //        Name="Alice",
            //        Password="123456",
            //            CreatedDate = DateTime.Now,
            //       ModifiedDate = DateTime.Now,
            //     Email="Alice@qq.com"
            //    },
            //    new SysUserInfo()
            //    {
            //           //Id = 3,
            //        Name="Ben",
            //        Password="123456",
            //           CreatedDate = DateTime.Now,
            //           ModifiedDate = DateTime.Now,
            //  Email="Ben@qq.com"
            //    }
            //};
            //var roles = new List<SysRole>()
            //{
            //    new SysRole()
            //    {
            //        //Id =1,
            //        Name="Administrator",
            //            ModifiedDate = DateTime.Now,
            //    Description="Administrator have full authorization to perform Sys administration."
            //    },
            //    new SysRole()
            //    {
            //        //Id = 2,
            //        Name="General User",
            //          ModifiedDate = DateTime.Now,
            //      Description="General User can access the data they are authorized for."
            //    }
            //};
            //var SysUserRoles = new List<SysUserRole>()
            //{
            //    new SysUserRole()
            //    {
            //        SysUserID = 1,
            //           ModifiedDate = DateTime.Now,
            //     SysRoleID = 1
            //    },
            //    new SysUserRole()
            //    {
            //        SysUserID = 1,
            //           ModifiedDate = DateTime.Now,
            //     SysRoleID = 2
            //    },
            //    new SysUserRole()
            //    {
            //          ModifiedDate = DateTime.Now,
            //      SysUserID = 3,
            //        SysRoleID = 2
            //    },
            //    new SysUserRole()
            //    {
            //        SysUserID = 2,
            //           ModifiedDate = DateTime.Now,
            //     SysRoleID = 1
            //    },
            //};
            //context.SysUserInfos.AddRange(users);
            //context.SysRoles.AddRange(roles);
            //context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
