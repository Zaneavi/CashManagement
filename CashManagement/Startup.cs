using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CashManagement.Startup))]
namespace CashManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
