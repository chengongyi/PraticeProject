using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait002
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 我是主线程，线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            TestAsync1();
            Console.ReadLine();
        }

        static async Task TestAsync()
        {
            Console.WriteLine("2 调用GetReturnResult()之前，线程ID：{0}。当前时间：{1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
            var name = GetReturnResult();
            Console.WriteLine("4 调用GetReturnResult()之后，线程ID：{0}。当前时间：{1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
            Console.WriteLine("6 得到GetReturnResult()方法的结果：{0}。当前时间：{1}", await name, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
        }

        static async Task TestAsync1()
        {
            Console.WriteLine("2 调用GetReturnResult()之前，线程ID：{0}。当前时间：{1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
            var name = GetReturnResult();
            Console.WriteLine("4 调用GetReturnResult()之后，线程ID：{0}。当前时间：{1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
            Console.WriteLine("6 得到GetReturnResult()方法的结果：{0}。当前时间：{1}",  name.GetAwaiter().GetResult(), DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
        }

        static async Task<string> GetReturnResult()
        {
            Console.WriteLine("3 执行Task.Run之前, 线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            return await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("5 GetReturnResult()方法里面线程ID: {0}", Thread.CurrentThread.ManagedThreadId);
                return "我是返回值";
            });
        }
    }
}
