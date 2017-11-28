using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait003
{
    class Program
    {
        /*
         *   
     （1）关键字：方法头使用 async 修饰。
     （2）要求：包含 N（N>0） 个 await 表达式（不存在 await 表达式的话 IDE 会发出警告），表示需要异步执行的任务。
     （3）返回类型：只能返回 3 种类型（void、Task 和 Task<T>）。Task 和 Task<T> 标识返回的对象会在将来完成工作，表示调用方法和异步方法可以继续执行。
     （4）参数：数量不限，但不能使用 out 和 ref 关键字。
     （5）命名约定：方法后缀名应以 Async 结尾。
     （6）其它：匿名方法和 Lambda 表达式也可以作为异步对象；async 是一个上下文关键字；关键字 async 必须在返回类型前。
         */

        static void Main(string[] args)
        {
            Console.WriteLine("开始下载图片");

            Task<string> imgTask= GetContentAsync();

            DoJob();

            Console.WriteLine("获取了结果");
            Console.WriteLine(imgTask.Result);

            Console.ReadKey();
        }

        static void DoJob()
        {
            Console.WriteLine("干其他的事情，非常耗时");
            Thread.Sleep(1000);
            Console.WriteLine("执行了很耗时的工作");
        }

        static async Task<string> GetContentAsync()
        { 
            var content = await GetString();
            return content.ToString();
        }

        static async Task<string> GetString()
        {
            return await Task.Run(() => {
                return "123";
            });
            
        }
         
    }
}
