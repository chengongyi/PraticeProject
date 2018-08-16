using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SettingDemo2
{
    public class AppSettings
    {
        public Window Window { get; set; }
        public Connection Connection { get; set; }
        public Profile Profile { get; set; }
    }

    public class Window
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class Connection
    {
        public string Value { get; set; }
    }

    public class Profile
    {
        public string Machine { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");

            var config = builder.Build();

            //1.使用绑定的方式，把Setting绑定到类中
            var appConfig = new AppSettings(); 
            config.GetSection("App").Bind(appConfig);


            //2.直接从配置文件取出数据，并且加载到类中
            var appConfig1 = config.GetSection("App").Get<AppSettings>();


            Console.WriteLine(appConfig.Connection);
            Console.WriteLine(appConfig1.Connection);


        }
    }
}
