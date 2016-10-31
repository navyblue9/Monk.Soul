using Hangfire;
using Microsoft.Owin;
using Monk.Utils;
using Owin;

[assembly: OwinStartup(typeof(Monk.HangfireStartup))]
namespace Monk
{
    public class HangfireStartup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(Keys.ConnectionStringKey);
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}