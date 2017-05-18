using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lucy.Startup))]
namespace Lucy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
