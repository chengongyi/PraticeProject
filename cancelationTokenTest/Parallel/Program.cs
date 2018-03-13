using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parallel.For(0, 10, i => DoWork(i));


            //并行执行他们
            Parallel.Invoke(
                () => Method1(),
                () => Method2(),
                () => Method3()
                );

            TaskScheduler
        }

        private static void DoWork(int i)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"当前的值是:{i},ThreaId:{Thread.CurrentThread.ManagedThreadId}");
        }

        private static void Method1()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Method1 is done");
        }

        private static void Method2()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Method2 is done");
        }

        private static void Method3()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Method3 is done");
        }
    }
}
