using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinuteWith
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<Int32> t=new Task<int>(n=>Sum((Int32)n),10000); 

            t.Start();

            Task cwt = t.ContinueWith(task => Console.WriteLine("the sum is" + task.Result));

        }

        private static Int32 Sum( Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                checked
                {
                    sum += n;
                }
            }
            return sum;
        }
    }
}
