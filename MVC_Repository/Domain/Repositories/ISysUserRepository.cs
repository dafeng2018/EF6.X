using MVC_Repository.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Repository.Domain.Repositories
{
    interface ISysUserRepository
    {
        IEnumerable<SysUserInfo> GetUsers();
        SysUserInfo GetUserByID(int userID);
        void InsertUser(SysUserInfo user);
        void DeletetUser(int userID);
        void UpdateUser(SysUserInfo user);
        void Save();
    }
}
