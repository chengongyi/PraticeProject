using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread002
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(Run));

            t.Start();

            //如果终止工作线程，只能管到一次，工作线程的下一次sleep就管不到了，相当于一个 contine操作
            t.Interrupt();

            //这个就是相当于一个break操作，工作线程彻底死掉。 
            // t.Abort();  
        }

        static void Run1(object i)
        {

        }

        static void Run()
        {
            for (int i = 1; i <=3; i++)
            {
                Stopwatch watch = new Stopwatch();
                try
                {
                    watch.Start();

                    Thread.Sleep(2000);

                    watch.Stop();

                    Console.WriteLine("第{0}延迟执行：{1}ms", i, watch.ElapsedMilliseconds);
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine("第{0}延迟执行：{1}ms,不过抛出异常", i, watch.ElapsedMilliseconds);
                }
            }
        }
    }
}
