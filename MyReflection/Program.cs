using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Type
            //string n = "grayworm";
            //Type t = n.GetType();
            //foreach (var mi in t.GetMembers())
            //{
            //    Console.WriteLine("{0}/t{1}", mi.MemberType, mi.Name);
            //}
            #endregion
            #region -
            ObjectHandle handle = Activator.CreateInstance("MyReflection", "MyReflection.Person");
            Person p = (Person)handle.Unwrap();
            Console.WriteLine(p.GetType().GetMethod("PrintName"));
            Console.WriteLine(p.PrintName());
            foreach (var item in p.GetType().GetMethods())
            {
                Console.WriteLine(item.Name);
            }
            #endregion
        }
    }
}
//从一个对象的外部去了解对象内部的构造，而且都是利用了波的反射功能。在.NET中的反射也可以实现从对象的外部来了解对象（或程序集）内部结构的功能，哪怕你不知道这个对象（或程序集）是个什么东西，另外.NET中的反射还可以运态创建出对象并执行它其中的方法。