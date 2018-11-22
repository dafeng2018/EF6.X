using System.Collections.Generic;

namespace One2One
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual StudentContact Contact { get; set; }
    }
}
