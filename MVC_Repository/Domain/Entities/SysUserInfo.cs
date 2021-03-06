﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Repository.Domain.Entities
{
    public class SysUserInfo
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string CName { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }
    }
}