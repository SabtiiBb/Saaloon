using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Saaloon.Startup))]
namespace Saaloon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
