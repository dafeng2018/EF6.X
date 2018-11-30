using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_04.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }


    }
}