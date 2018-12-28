using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    public class Person
    {
        private string name = "Hi";

        public Person() { }

        public Person(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public override string ToString()
        {
            return this.name;
        }
        public string PrintName()
        {
            return this.name;
        }
    }
}
