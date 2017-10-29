using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Framework.Config
{
    public class ApplicationConfig
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(Data.DBContext.Create);
        }
    }
}
