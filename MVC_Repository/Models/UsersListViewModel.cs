using MVC_Repository.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Repository.Models
{
    public class UsersListViewModel
    {
        public IEnumerable<SysUserInfo> SysUserInfos { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}