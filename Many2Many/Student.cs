using System.Collections.Generic;

namespace Many2Many
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}