using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Web.Domain.Entity
{
    public class Teacher : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StudentCount { get; set; }
    }
}
