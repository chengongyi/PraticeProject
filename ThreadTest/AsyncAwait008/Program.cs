using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait008
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            var t = Do.ExecuteAsync(token);

            Thread.Sleep(2000);

            source.Cancel();

            if (!token.IsCancellationRequested) {
                t.Wait(token);
            }
            else
            {
                Console.WriteLine("任务被终止了");
            }
      

            Console.WriteLine($"{nameof(token.IsCancellationRequested)}:{token.IsCancellationRequested}");
        }
    }

    class Do
    {
        public static async Task ExecuteAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            await Task.Run(() => CircleOutput(token));
        }

        private static void CircleOutput(CancellationToken token)
        {
            Console.WriteLine("开始调用方法");

            const int num = 5;

            for (int i = 0; i < num; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                Console.WriteLine($"{i+1}/{num} 完成");
                Thread.Sleep(1000);

            }
        }
    }


}
