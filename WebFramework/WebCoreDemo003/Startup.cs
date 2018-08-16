using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebCoreDemo003
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IStartupFilter, RequestSetOptionsStartupFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

    public class AppOptions
    {
        public string Option { get; set; } = "Option Default Value";

    }

    public class RequestSetOptionsMiddleware
    {
        //这个 委托类非常的重要，系统也就是用它，把所有的中间件串起来的
        private readonly RequestDelegate _next;

        //这是一个注入的配置
        private IOptions<AppOptions> _injectedOptions;

        //这是注入的参数，这里要注意一下，这里的参数是什么时候注入进来的
        /*
         * 自定义一个中间件的时候，必须传入这些东西吗？
         */
        public RequestSetOptionsMiddleware(RequestDelegate next, IOptions<AppOptions> injectedOptions)
        {
            _next = next;
            _injectedOptions = injectedOptions;
        }

        /*
         * 这貌似是必须写的方法，接口一个上下文的 Invoke方法，并且返回一个Task
         */
        public async Task Invoke(HttpContext httpContext)
        {
            var option = httpContext.Request.Query["option"];
            _injectedOptions.Value.Option= WebUtility.HtmlEncode(option);
            await _next(httpContext);
        } 
    }

    public class RequestSetOptionsStartupFilter : IStartupFilter
    {
        /*
         * 使用委托还有个什么好处呢，就是 我们在具体开发一个委托的时候，
         * 都不需要声明一个委托类型，直接使用 lambada表达式就能够
         * 声明了
         * 
         * 这个startUp过滤器 有点承上启下的味道，接受一个next参数，其实这个next就是管道的下一个
         * 事件，我们可以对他进行短路。
         * 
         * 
         */
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<RequestSetOptionsMiddleware>();
                next(builder);
            };
        }
    }

}
