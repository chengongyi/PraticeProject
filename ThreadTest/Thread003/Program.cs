using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread003
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Run));
            t.Start(123);
            t.Join();

            Console.WriteLine("我是主线程：" + Thread.CurrentThread.GetHashCode());
        }

        private static void Run(object obj)
        {
            Thread.Sleep(1000);
            Console.WriteLine("我是线程：" + Thread.CurrentThread.GetHashCode());
            Console.WriteLine("Run的参数为:"+obj.ToString());
        
        }
    }
}
