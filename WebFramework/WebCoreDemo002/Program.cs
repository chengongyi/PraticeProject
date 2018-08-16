using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebCoreDemo002
{

    /*
     * 虽然这种方式也可以达到目的，但是，这违反了SRP原则。看起来代码很乱
     * 
     */
    public class Program
    {
        //上下文
        public static IHostingEnvironment HostingEnvironment { get; set; }

        //配置文件
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseStartup<Startup>();
                //配置应用程序配置 
                /* 
                 * 这里其实就是应用程序配置目录了，可以获取上下文和 配置类
                 */
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    HostingEnvironment = hostingContext.HostingEnvironment;
                    Configuration = config.Build();
                })

                //配置信息
                .ConfigureServices(services =>
                {
                    services.AddMvc();
                })

                //配置中间件管道信息
                .Configure(app =>
                {
                    if (HostingEnvironment.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                    }

                    app.UseMvcWithDefaultRoute();

                    app.UseStaticFiles();
                });

    }
}
