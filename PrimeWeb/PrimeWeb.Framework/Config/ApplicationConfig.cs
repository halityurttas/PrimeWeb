﻿using Owin;

namespace PrimeWeb.Framework.Config
{
    public abstract class ApplicationConfig
    {
        public void InitializeAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(Data.DBContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        }
    }
}
