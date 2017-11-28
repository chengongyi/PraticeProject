using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait012
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = GetNumber();
            Console.WriteLine(t.Result);
        }

        static async Task<int> GetNumber()
        {
            var t1 = Task.Run(() =>
            {
                Thread.Sleep(new Random().Next(10) * 100);
                return new Random().Next(1, 100);
            });

            var t2 = Task.Run(() =>
            {
                Thread.Sleep(new Random().Next(10) * 100);
                return new Random().Next(1,100);
            });

            await Task.WhenAll(new List<Task<int>>() { t1, t2 });


            Console.WriteLine($"    t1.{nameof(t1.IsCompleted)}: {t1.IsCompleted}");

            Console.WriteLine($"    t2.{nameof(t2.IsCompleted)}: {t2.IsCompleted}");

            return t1.Result + t2.Result;
        }
    }
}
