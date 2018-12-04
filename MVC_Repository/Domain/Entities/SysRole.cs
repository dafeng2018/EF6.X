using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Repository.Domain.Entities
{
    public class SysRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CName { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }
    }
}