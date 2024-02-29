using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kutse.Startup))]
namespace kutse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
