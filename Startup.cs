using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayRentAndUse_V3.Startup))]
namespace PayRentAndUse_V3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
