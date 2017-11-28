using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait011
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = GerRandomAsync(1);
            var t2 = GerRandomAsync(2);

            Task<int>[] tasks = new Task<int>[] { t1,t2};

            //这里只需要有一个任务完成了，然后就可以往下执行
            Task.WaitAny(tasks);


            //这里需要每一个任务都执行成功了，然后才能往下执行
            Task.WhenAll(tasks);

          

            Console.WriteLine($"t1.{nameof(t1.IsCompleted)} {t1.IsCompleted}" );
            Console.WriteLine($"t2.{nameof(t2.IsCompleted)} {t2.IsCompleted}");

            Console.Read();

        }
        static async Task<int> GerRandomAsync(int id)
        {
            var num = await Task.Run(()=> {
                Thread.Sleep(new Random().Next(10) * 100);
                return new Random().Next();
            });

            Console.WriteLine($"{id} 已经调用完成");
            return num;
        }
    }
}
