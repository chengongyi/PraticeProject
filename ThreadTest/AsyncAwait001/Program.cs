using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait001
{
    class Program
    {
        static void Main(string[] args)
        {
            Async1();

            Console.WriteLine("aaa's id=" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("aaa");

            Console.Read();

            /*
             * 这里的执行顺序为：a,b,c
             */
        } 

       static async void Async1()
        {
      
            await Task.Run(() =>
            {
                Console.WriteLine("begin to run bbb");
                Thread.Sleep(1000); 
                Console.WriteLine("bbb");
                Console.WriteLine("bbb's id=" + Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("ccc");
            Console.WriteLine("ccc's id=" + Thread.CurrentThread.ManagedThreadId);
        }


    }
}
