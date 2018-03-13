using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cancelationTokenTest
{
    class Program
    {
        static void Main(string[] args)
        {
             CancellationTokenSource cts=new CancellationTokenSource();
            Task<Int32> t=new Task<int>(()=>Sum(cts.Token,1),cts.Token);
            t.Start();

            cts.Cancel();
             
            try
            {
                Console.WriteLine("the sum is:"+t.Result);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("suem was canceled!");
            }

            Console.WriteLine("keep going"); 
        }

        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (;n>0;n--)
            {
                ct.ThrowIfCancellationRequested();
                checked
                {
                    sum += n;
                }
            }
            return sum;
        }

        private static void NewMethod()
        {
            var cts = new CancellationTokenSource();

            cts.Token.Register(() => Console.WriteLine("Canceled 1"));

            cts.Token.Register(() => Console.WriteLine("Canceled 2"));

            cts.Cancel();
        }
    }
}
