using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project5_CSE598.Startup))]
namespace Project5_CSE598
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
