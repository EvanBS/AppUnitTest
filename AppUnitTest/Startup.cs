using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppUnitTest.Startup))]
namespace AppUnitTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
