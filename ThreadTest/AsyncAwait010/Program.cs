using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait010
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = CountAsync("http://www.mmjpg.com/");

            t.Wait();

            Console.WriteLine(t.Result);

        }

        static async Task<string> CountAsync(string address)
        {
            var result = await Task.Run(() => new WebClient().DownloadStringTaskAsync(address));

            var result2 = await Task.Run(()=> 
                new HttpClient().GetStringAsync(address)
            );

            return result2.ToString();
        }
    }
}
