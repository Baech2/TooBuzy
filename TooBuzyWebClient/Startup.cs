using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TooBuzyWebClient.Startup))]
namespace TooBuzyWebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
