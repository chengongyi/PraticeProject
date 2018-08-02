using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfireTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget"));
        }
    }
}
