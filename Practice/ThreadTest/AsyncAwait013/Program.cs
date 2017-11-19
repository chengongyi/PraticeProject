using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait013
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{nameof(Main)} - start.");
            DoAsync();
            Console.WriteLine($"{nameof(Main)} - end.");

            Console.Read();
        }

        static async Task DoAsync()
        {
            Console.WriteLine("begin");

            //await Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("hello world");
            //});

            //这里不同于Thread.Sleep(5000); 这里不会阻塞线程，而是而是立即返回了
            //await Task.Delay(1000);

            Thread.Sleep(1000);

            Console.WriteLine("end");
        }
    }
}
