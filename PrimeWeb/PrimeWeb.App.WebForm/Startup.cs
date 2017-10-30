using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimeWeb.App.WebForm.Startup))]
namespace PrimeWeb.App.WebForm
{
    public partial class Startup : Framework.Config.ApplicationConfig
    {
        public void Configuration(IAppBuilder app)
        {
            InitializeAuth(app);
            ConfigureAuth(app);
        }
    }
}
