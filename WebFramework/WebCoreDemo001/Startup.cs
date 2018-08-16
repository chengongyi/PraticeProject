using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebCoreDemo001
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
             * 小心得：为什么参数传入设计成  Action<xxxx>?
             * 归根结底其实就是传入了一个行为进去，他在某个时间节点，会把这段代码运行起来
             * 
             * 这样做的好处是，我们可以重用最里面的逻辑，可以把配置相关的行为交给用户来决定
             * 
             * 设计SDK的时候，把易于改动的地方，做成活的，使用委托则可以实现这一点！
             * 
             * 这里的AddMvcOptions里面带了一个委托，多个Add方法，最终被串成一起，变成委托链
             * 
             * 而且 ConfigureServices 看起来就是进行配置的地方
            */

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).
                AddMvcOptions(options =>
                {
                    options.AllowCombiningAuthorizeFilters = false;
                    options.InputFormatterExceptionPolicy = InputFormatterExceptionPolicy.AllExceptions;
                });

            services.AddMyService()
                .AddMyService(option=> {
                    option.Value.Size = 123;
                })
                .AddGoodService();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /*
             * 1.指定响应HTTP 的方式
             * 2.把中间件添加到IApplicationBuilder中
             */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
             * 1.把路由中间件添加到请求管道，这里的中间件就和之前的Filter差不多
             * 2.每个中间件都负责调用下一个中间
             * 3.中间件可以使链短路，也就是用过滤器给拦截了
             */
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action=Index}/{id?}");
            });
        }
    }

    public class TempOptions
    {
        public int Size { get; set; }
    }

    public static class Extension
    {
        public static IServiceCollection AddMyService(this IServiceCollection services)
        {
            services.AddScoped<IMyService, MyService>();
            return services;
        }

        public static IServiceCollection AddMyService(this IServiceCollection services,IOptions<TempOptions> options)
        {
            services.AddScoped<IMyService, MyService>();
            return services;
        }

        public static IServiceCollection AddMyService(this IServiceCollection services,Action<IOptions<TempOptions>> action)
        {
            services.AddScoped<IMyService, MyService>();
            return services;
        }

        public static IServiceCollection AddGoodService(this IServiceCollection services)
        {
            services.AddScoped<IMyService, MyService>();
            return services;
        }
    }

}
