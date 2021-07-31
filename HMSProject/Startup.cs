using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HMSProject.Startup))]

namespace HMSProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}