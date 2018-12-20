using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPolly
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 用Polly指定该异常并重试三次

            //try
            //{
            //    var retryTwoTimesPolicy = Policy.Handle<DivideByZeroException>().Retry(3, (ex, count) =>
            //    {
            //        Console.WriteLine("执行失败! 重试次数 {0}", count);
            //        Console.WriteLine("异常来自 {0}", ex.GetType().Name);
            //    });
            //    retryTwoTimesPolicy.Execute(() => { Compute(); });
            //}
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine($"Excuted Failed,Message: ({e.Message})");
            //}

            #endregion
            #region Polly等待重试
            try
            {
                var politicaWaitAndRetry = Policy
                    .Handle<DivideByZeroException>()
                    .WaitAndRetry(new[]
                    {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(3),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(7)
                    }, ReportaError);
                politicaWaitAndRetry.Execute(() =>
                {
                    ZeroExcepcion();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Executed Failed,Message:({e.Message})");
            }
            #endregion
        }

        static int Compute()
        {
            var a = 0;
            return 1 / a;
        }

        /// <summary>
        /// 抛出异常
        /// </summary>
        static void ZeroExcepcion()
        {
            throw new DivideByZeroException();
        }

        /// <summary>
        /// 异常信息
        /// </summary>
        /// <param name="e"></param>
        /// <param name="tiempo"></param>
        /// <param name="intento"></param>
        /// <param name="contexto"></param>
        static void ReportaError(Exception e, TimeSpan tiempo, int intento, Context contexto)
        {
            Console.WriteLine($"异常: {intento:00} (调用秒数: {tiempo.Seconds} 秒)\t执行时间: {DateTime.Now}");
        }
    }
}
