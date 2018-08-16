using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VolatileTest001
{
    class Program
    {
        private static Boolean flag = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Main:letting wokrer run for 5 seconds");

            Thread t=new Thread(Worker);  
            t.Start();

            Thread.Sleep(5000);

            flag = true;

            Console.WriteLine("Main:waiting for workeer to stop");

            t.Join();
        }

        private static void Worker(object o)
        {
            Int32 x = 0;
            while (!flag) x++;
            Console.WriteLine($"worker：stopped when x={x}");
        
          WaitHandle
    }
}
