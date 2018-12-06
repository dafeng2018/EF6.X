using MVC_Repository.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC_Repository.Domain.Concrete
{
    internal class EFDbInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var users = new List<SysUserInfo>()
            {
                new SysUserInfo()
                {
                    //Id = 1,
                    Name="Admin",
                    Password="123456",
                    ModifiedDate = DateTime.Now,
                    Email="Alice@qq.com"
                },
                new SysUserInfo()
                {
                    //Id = 2,
                    Name="Alice",
                    Password="123456",
                       ModifiedDate = DateTime.Now,
                 Email="Alice@qq.com"
                },
                new SysUserInfo()
                {
                       //Id = 3,
                    Name="Ben",
                    Password="123456",
                          ModifiedDate = DateTime.Now,
              Email="Ben@qq.com"
                }
            };
            var roles = new List<SysRole>()
            {
                new SysRole()
                {
                    //Id =1,
                    Name="Administrator",
                        ModifiedDate = DateTime.Now,
                Description="Administrator have full authorization to perform Sys administration."
                },
                new SysRole()
                {
                    //Id = 2,
                    Name="General User",
                      ModifiedDate = DateTime.Now,
                  Description="General User can access the data they are authorized for."
                }
            };
            var SysUserRoles = new List<SysUserRole>()
            {
                new SysUserRole()
                {
                    SysUserID = 1,
                       ModifiedDate = DateTime.Now,
                 SysRoleID = 1
                },
                new SysUserRole()
                {
                    SysUserID = 1,
                       ModifiedDate = DateTime.Now,
                 SysRoleID = 2
                },
                new SysUserRole()
                {
                      ModifiedDate = DateTime.Now,
                  SysUserID = 3,
                    SysRoleID = 2
                },
                new SysUserRole()
                {
                    SysUserID = 2,
                       ModifiedDate = DateTime.Now,
                 SysRoleID = 1
                },
            };
            context.SysUserInfos.AddRange(users);
            context.SysRoles.AddRange(roles);
            context.SaveChanges();
        }
    }
}
