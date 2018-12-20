using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPolly
{
    #region Polly - 1
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        #region Polly指定该异常并重试三次

    //        //try
    //        //{
    //        //    var retryTwoTimesPolicy = Policy.Handle<DivideByZeroException>().Retry(3, (ex, count) =>
    //        //    {
    //        //        Console.WriteLine("执行失败! 重试次数 {0}", count);
    //        //        Console.WriteLine("异常来自 {0}", ex.GetType().Name);
    //        //    });
    //        //    retryTwoTimesPolicy.Execute(() => { Compute(); });
    //        //}
    //        //catch (DivideByZeroException e)
    //        //{
    //        //    Console.WriteLine($"Excuted Failed,Message: ({e.Message})");
    //        //}

    //        #endregion
    //        #region Polly等待重试
    //        //try
    //        //{
    //        //    var politicaWaitAndRetry = Policy
    //        //        .Handle<DivideByZeroException>()
    //        //        .WaitAndRetry(new[]
    //        //        {
    //        //            TimeSpan.FromSeconds(1),
    //        //            TimeSpan.FromSeconds(3),
    //        //            TimeSpan.FromSeconds(5),
    //        //            TimeSpan.FromSeconds(7)
    //        //        }, ReportaError);
    //        //    politicaWaitAndRetry.Execute(() =>
    //        //    {
    //        //        ZeroExcepcion();
    //        //    });
    //        //}
    //        //catch (Exception e)
    //        //{
    //        //    Console.WriteLine($"Executed Failed,Message:({e.Message})");
    //        //}
    //        #endregion
    //        #region Polly反馈策略
    //        var fallBackPolly = Policy<string>.Handle<Exception>().Fallback("执行失败，返回Fallback");
    //        var fallBack = fallBackPolly.Execute(() => {
    //            return ThrowException();
    //        });
    //        Console.WriteLine(fallBack);

    //        #endregion
    //    }
    //    static int Compute()
    //    {
    //        var a = 0;
    //        return 1 / a;
    //    }

    //    /// <summary>
    //    /// 抛出异常
    //    /// </summary>
    //    static void ZeroExcepcion()
    //    {
    //        throw new DivideByZeroException();
    //    }

    //    /// <summary>
    //    /// 异常信息
    //    /// </summary>
    //    /// <param name="e"></param>
    //    /// <param name="tiempo"></param>
    //    /// <param name="intento"></param>
    //    /// <param name="contexto"></param>
    //    static void ReportaError(Exception e, TimeSpan tiempo, int intento, Context contexto)
    //    {
    //        Console.WriteLine($"异常: {intento:00} (调用秒数: {tiempo.Seconds} 秒)\t执行时间: {DateTime.Now}");
    //    }
    //    static string ThrowException()
    //    {
    //        throw new Exception();
    //    }
    //}
    #endregion
    #region Polly -2
    //定义条件： 定义你要处理的 错误异常/返回结果
    //定义处理方式 ： 重试，熔断，回退
    //执行
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var policy = Policy.Handle<DivideByZeroException>().Retry(3, (ex, count) =>
                {
                    Console.WriteLine("Fail - {0}, Error  - {1}", count, ex.GetType().Name);
                });
                policy.Execute(() => ZeroExcepcion());

            }
            catch (DivideByZeroException e)
            {

                Console.WriteLine(e.Message);
            }
        }
        static void ZeroExcepcion()
        {
            throw new DivideByZeroException();
        }
    }
    #endregion
}
