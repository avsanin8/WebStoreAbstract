using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeStoreAbstract.Startup))]
namespace HomeStoreAbstract
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
