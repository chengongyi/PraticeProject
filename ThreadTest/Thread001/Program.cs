using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread001
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Run);

            t.Start();

            //让并发行--->串行化
            t.Join();

            Console.WriteLine("我是主线程："+Thread.CurrentThread.GetHashCode());
        }


        static void Run()
        {
            Thread.Sleep(5000);

            Console.WriteLine("我是线程："+Thread.CurrentThread.GetHashCode());
        }
    }
}
