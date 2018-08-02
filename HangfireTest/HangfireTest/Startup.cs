using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(HangfireTest.Startup))]

namespace HangfireTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("<name or connection string>");

            app.UseHangfireDashboard();

            app.UseHangfireServer();
        }
    }
}
