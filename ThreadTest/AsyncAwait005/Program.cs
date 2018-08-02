using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait005
{
    class Program
    {
        static void Main(string[] args)
        {
            var task=Caculator.CountAsync(10, 30);

            //等待任务全部执行完毕
            //task.Wait();

            //获得返回的结果
            Console.WriteLine(task.Result);
           

            Console.WriteLine("方法已经执行完毕了");

            Console.ReadKey();
        }
    }

    class Caculator
    {
        public static async Task Count(int a,int b)
        {

            int  task = await Task.Run(()=> {
                Console.WriteLine("开始执行计算方法");

                Thread.Sleep(2000);

                return a + b;
            });

            Console.WriteLine("计算出了结果:"+task);
        }

        public static async Task<int> CountAsync(int a, int b)
        {
            var val = await Task.Run(()=> {
                Console.WriteLine("开始执行计算方法");

                Thread.Sleep(2000);

                return a + b;

            });
            return val;
        }
    }
}
