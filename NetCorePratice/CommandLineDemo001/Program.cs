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
                {"A", "AAAA"},
                {"B", "BBBB"}
            };

            //想要动态的使用Configuration 必须使用 Builder
            var builder = new ConfigurationBuilder();

            //添加字典到缓存中
            builder.AddInMemoryCollection(dict)
                //使用命令行配置替代由其他配置提供程序提供的配置,最后得加上AddCommandLine，这样一来就能看到
                .AddCommandLine(args); 

            //使用 Build 构建一个新的配置
            Configuration = builder.Build();



            Console.WriteLine($"A: {Configuration["A"]}");
            Console.WriteLine($"B: {Configuration["B"]}");
            Console.WriteLine();

            Console.WriteLine("Press a key...");
            Console.ReadKey();
        }
    }
}
