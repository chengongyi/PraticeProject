using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CommandLineDemo001
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>
            {
                {"Profile:MachineName", "MairaPC"},
                {"App:MainWindow:Left", "1980"}
            };

            //想要动态的使用Configuration 必须使用 Builder
            var builder = new ConfigurationBuilder();
        }
    }
}
