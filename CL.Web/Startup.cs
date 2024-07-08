using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetAuthentication.Startup))]
namespace GetAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
