using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace SettingDemo001
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            //配置文件可以通过文件传入
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            /*
             * 通过ConfigurationBuilder 明确指定配置文件和路径。然后赋值给上下文
             * 也就是说，我们可以在普通的类型项目中，通过这种方式，把配置文件加载到全局上下文中
             * 
             */
            Configuration = builder.Build();

            /*
             * 取出数值的时候：
             * 上下文分割：则使用：
             * 取出索引：使用 数值去取
             */
            System.Console.WriteLine($"option1 GetSection:{Configuration.GetSection("Option1").Value}");
            System.Console.WriteLine($"option1:{Configuration["Option1"]}");
            System.Console.WriteLine($"suboption1:{Configuration["subsection:suboption1"]}");
            System.Console.WriteLine($"Harry:17:{Configuration["wizards:1:Name"]}");
            System.Console.WriteLine($"Harry:17:{Configuration["wizards:1:Age"]}");



            ///配置信息可以通过字典数据传入
            var dict = new Dictionary<string, string>
            {
                {"Profile:MachineName", "Rick"},
                {"App:MainWindow:Height", "11"},
                {"App:MainWindow:Width", "11"},
                {"App:MainWindow:Top", "11"},
                {"App:MainWindow:Left", "11"}
            };

            var builder1 = new ConfigurationBuilder();
            builder1.AddInMemoryCollection(dict);
            Configuration = builder1.Build();

            //1.直接读取
            System.Console.WriteLine($"Profile:MachineName:{Configuration["Profile:MachineName"]}");



            //2.把数据提取到POCO类中
            var window = new MyWindow();
            Configuration.GetSection("App:MainWindow").Bind(window);
            System.Console.WriteLine($"window.Left={window.Left}");

            //3.使用GetValue,如果找不到这个值，还可以附上一个默认的值，这在开发时很有用
            var left = Configuration.GetValue<int>("App:MainWindow:Left", 80);
            Console.WriteLine($"Configuration.GetValue.Left {left}");



        }
        public class MyWindow
        {
            public int Height { get; set; }
            public int Width { get; set; }
            public int Top { get; set; }
            public int Left { get; set; }
        }
    }
}
