using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {

        #region Lambda1

        //static void Main(string[] args)
        //{
        //    Func<string, int> val = x => x.Length;
        //    Console.WriteLine(val("123"));
        //    DoSomeStuff();
        //    var lang = "de";
        //    //Get language - e.g. by current OS settings
        //    var smn = SayMyName(lang);
        //    var name = "name";
        //    var sentence = smn(name);
        //    Console.WriteLine(sentence);

        //    Console.WriteLine(Translations.GetSayMyName("de").Invoke("1000"));
        //    var fun = Translations.GetSayMyName("fr");
        //    Console.WriteLine(fun("112233"));

        //    Func<int, int> result = x => x * 10;

        //    Action<int> loopBody = i =>
        //    {
        //        if (i > 5)
        //        {

        //            loopBody = x => Console.WriteLine(" i>5 " + x * 10);
        //            //Console.WriteLine(index * 10);
        //        }
        //        else
        //        {
        //            loopBody = x => Console.WriteLine(" i<=5 " + x * 10);
        //            //Console.WriteLine(index * 100);

        //        }
        //    };

        //    for (int j = 10; j > 0; j--)
        //    {
        //        var index = j;
        //        loopBody(index);
        //    }

        //    //((string s, int no) =>
        //    //{
        //    //    // Do Something here!
        //    //    Console.WriteLine(s + no);
        //    //}) ("Example", 8);
        //    new Action(() => { Console.WriteLine("Hello World"); })();
        //    dynamic person = null;
        //    person = new
        //    {//Lambda表达式是不允许赋值给匿名对象的
        //        Name = "Florian",
        //        Age = 28,
        //        Ask = (Action<string>)((string question) =>
        //        {
        //            Console.WriteLine("The answer to `" + question + "` is certainly 42!" + person.Age);
        //        })
        //    };
        //    person.Ask("Why are you doing this?");

        //}
        //static void DoSomeStuff()
        //{
        //    var coeff = 10;
        //    Func<int, int> compute = x => coeff * x;
        //    Action modifier = () =>
        //    {
        //        coeff = 5;
        //    };

        //    var result1 = DoMoreStuff(compute);
        //    Console.WriteLine(result1);

        //    ModifyStuff(modifier);

        //    var result2 = DoMoreStuff(compute);
        //    Console.WriteLine(result2);
        //}

        //static int DoMoreStuff(Func<int, int> computer)
        //{
        //    return computer(5);
        //}

        //static void ModifyStuff(Action modifier)
        //{
        //    modifier();
        //}
        //static Func<string, string> SayMyName(string language)
        //{
        //    switch (language.ToLower())
        //    {
        //        case "fr":
        //            return name =>
        //            {
        //                return "Je m'appelle " + name + ".";
        //            };
        //        case "de":
        //            return name =>
        //            {
        //                return "Mein Name ist " + name + ".";
        //            };
        //        default:
        //            return name =>
        //            {
        //                return "My name is " + name + ".";
        //            };
        //    }
        //}
        //static class Translations
        //{
        //    static readonly Dictionary<string, Func<string, string>> smnFunctions = new Dictionary<string, Func<string, string>>();

        //    static Translations()
        //    {
        //        smnFunctions.Add("fr", name => "Je m'appelle " + name + ".");
        //        smnFunctions.Add("de", name => "Mein Name ist " + name + ".");
        //        smnFunctions.Add("en", name => "My name is " + name + ".");
        //    }

        //    public static Func<string, string> GetSayMyName(string language)
        //    {
        //        //Check if the language is available has been omitted on purpose
        //        return smnFunctions[language];
        //    }
        //}
        //class SomeClass
        //{
        //    public Func<int> NextPrime
        //    {
        //        get;
        //        private set;
        //    }

        //    int prime;

        //    public SomeClass()
        //    {
        //        NextPrime = () =>
        //        {
        //            prime = 2;

        //            NextPrime = () =>
        //            {
        //                // 这里可以加上 第二次和第二次以后执行NextPrive()的逻辑代码
        //                return prime;
        //            };

        //            return prime;
        //        };
        //    }
        //}
        #endregion
        #region Lambda2
        static void Main(string[] args)
        {
            //Expression<Func<int, int>> expr = x => x + 1;
            //Console.WriteLine(expr.ToString());  // x=> (x + 1)

            //var lambdaExpr = expr as LambdaExpression;
            //Console.WriteLine(lambdaExpr.Body);   // (x + 1)
            //Console.WriteLine(lambdaExpr.ReturnType.ToString());  // System.Int32

            //foreach (var parameter in lambdaExpr.Parameters)
            //{
            //    Console.WriteLine("Name:{0}, Type:{1}, ", parameter.Name, parameter.Type.ToString());
            //}
            //Console.WriteLine("---------------------------");
            //LoopExpression loop = Expression.Loop(
            //    Expression.Call(
            //        null,
            //        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
            //        Expression.Constant("Hello")
            //    )
            //);

            //// 创建一个代码块表达式包含我们上面创建的loop表达式
            //BlockExpression block = Expression.Block(loop);

            //// 将我们上面的代码块表达式
            //Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
            //lambdaExpression.Compile().Invoke();


            Expression<Func<Student, bool>> expression = t => t.Name == "HI";
            Func<Student, bool> func = t => t.Name == "HI";
            Student student = new Student { Name = "HI" };
            Console.WriteLine(func(student));
            student = new Student { Name = "HI" };
            Func<Student, bool> result = expression.Compile();
            Console.WriteLine(result(student));
        }
        #endregion
    }
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Sex { get; set; }
    }
}
//loopBody(10) - > x> 5 -> 