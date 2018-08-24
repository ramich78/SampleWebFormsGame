using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleWebFormsGame.Startup))]
namespace SampleWebFormsGame
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
