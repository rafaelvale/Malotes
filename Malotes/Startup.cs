using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Malotes.Startup))]
namespace Malotes
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
          //  ConfigureAuth(app);
        }
    }
}
