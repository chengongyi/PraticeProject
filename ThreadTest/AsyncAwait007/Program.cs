using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait007
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Do.GetGuidAsync();

            t.Wait();

            Console.Read();
        }
    }

    class Do
    {
        public static async Task GetGuidAsync()
        {
            //Action
            await Task.Run(() => { Console.WriteLine(Guid.NewGuid()); });

            //Func<TResult>
            Console.WriteLine(await Task.Run(()=>Guid.NewGuid()));

            //Func<Task>
            await Task.Run(() => Task.Run(() => { Console.WriteLine(Guid.NewGuid()); }));

            //Func<Task<TResult>>
            Console.WriteLine(await Task.Run(() => Task.Run(() => Guid.NewGuid())));
        }
    }

}
