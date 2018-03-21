using Microsoft.Owin;
// VV This reference must be present in order to run startup for Owin
using Microsoft.Owin.Host.SystemWeb;
using Owin;

[assembly: OwinStartup(typeof(MemeLord.Startup))]

namespace MemeLord
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
