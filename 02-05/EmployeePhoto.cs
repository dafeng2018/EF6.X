using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_05
{
    public class EmployeePhoto
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
