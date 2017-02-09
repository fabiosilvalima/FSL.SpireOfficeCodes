using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSL.SpireOffice.Mvc.Startup))]
namespace FSL.SpireOffice.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
