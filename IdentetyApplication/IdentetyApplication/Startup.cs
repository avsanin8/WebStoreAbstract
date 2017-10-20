using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentetyApplication.Startup))]
namespace IdentetyApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
