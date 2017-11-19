using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait004
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 20;

            var task = Calculator.AddAsync(a, b);

            Console.WriteLine(task.Result);
               
        }
    }

    internal class Calculator
    {

        public static int Add(int a,int b)
        {
            Thread.Sleep(1000);
            return a + b;
        }

        public static async Task<int> AddAsync(int a,int b)
        {
            //开启一个任务,让他自己执行耗时处理
            Task<int> t = Task.Run(() => Add(a, b));
             
            //等待他自己执行,然后返回结构
            int val = await t;

            //最终返回值
            return val;

             
            //int val = await Task.Run(() => Add(a, b));
            //return val;
        }
    }
}
