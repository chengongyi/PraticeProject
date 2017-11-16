
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOwin.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Install-Package Microsoft.Owin.Host.SystemWeb -Pre
             * 
             * Install-Package Microsoft.Owin.Diagnostics –Pre
             * 
             * Install-Package Microsoft.Owin.SelfHost -Pre
             */
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }
        }
    }
}
