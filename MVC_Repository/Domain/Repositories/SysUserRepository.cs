using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Repository.Domain.Entities;
using MVC_Repository.Domain.Concrete;

namespace MVC_Repository.Domain.Repositories
{
    public class SysUserRepository : ISysUserRepository
    {
        private EFDbContext context;
        public SysUserRepository(EFDbContext context)
        {
            this.context = context;
        }
        public void DeletetUser(int userID)
        {
            SysUserInfo user = context.SysUserInfos.Find(userID);
            context.SysUserInfos.Remove(user);
        }

        public SysUserInfo GetUserByID(int userID)
        {
            return context.SysUserInfos.Find(userID);
        }

        public IEnumerable<SysUserInfo> GetUsers()
        {
            return context.SysUserInfos.ToList();
        }

        public void InsertUser(SysUserInfo user)
        {
            context.SysUserInfos.Add(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateUser(SysUserInfo user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }
    }
}