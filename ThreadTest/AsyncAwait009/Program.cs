using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait009
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = DoExceptionAsync();
            t.Wait();

            Console.WriteLine($"{nameof(t.Status)}: {t.Status}");  //任务状态
            Console.WriteLine($"{nameof(t.IsCompleted)}: {t.IsCompleted}");     //任务完成状态标识
            Console.WriteLine($"{nameof(t.IsFaulted)}: {t.IsFaulted}");     //任务是否有未处理的异常标识


            //任务成功的执行了 因为：任务没有被取消，并且异常都已经处理完成！
        }

        static async Task DoExceptionAsync()
        {
            try
            {
                await Task.Run(() => {

                    //    throw new Exception();
                    var client = new HttpClient();
                    var str= client.GetStringAsync("http://www.mmjpg.com/");

                    //先做其他的动作先

                    Console.WriteLine("上个厕所先...");
                    Thread.Sleep(3000);
                    Console.WriteLine(str.Result);
                });
            }
            catch (Exception)
            {
                Console.WriteLine($"{nameof(DoExceptionAsync)} 出现异常！");
            }
        }
    }
}
