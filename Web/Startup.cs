using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebScraper.Web.Startup))]
namespace WebScraper.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
