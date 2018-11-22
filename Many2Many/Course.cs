using System.Collections.Generic;

namespace Many2Many
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public int MaximumStrength { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}