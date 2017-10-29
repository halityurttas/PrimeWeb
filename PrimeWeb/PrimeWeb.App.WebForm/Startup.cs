using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimeWeb.App.WebForm.Startup))]
namespace PrimeWeb.App.WebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            
        }
    }
}
