using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HelloOwin.ConsoleClient.Startup))]

namespace HelloOwin.ConsoleClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseErrorPage();

            app.Run(context => {

                if (context.Request.Path.Value == "/fail")
                {
                    throw new Exception("Random Exception");
                }

                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world. this is owin test");
            });
        }
    }
}
