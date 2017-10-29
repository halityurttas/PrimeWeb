using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using PrimeWeb.App.WebForm.Models;

namespace PrimeWeb.App.WebForm
{
    public partial class Startup {

        // Kimlik doğrulamayı yapılandırma hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkId=301883 adresini ziyaret edin.
        public void ConfigureAuth(IAppBuilder app)
        {
            // Veritabanı bağlamını, kullanıcı yöneticisini ve oturum açma yöneticisini istek başına tek bir örnek kullanacak şekilde yapılandır
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Oturum açan kullanıcıya ilişkin bilgileri depolamak üzere bir tanımlama bilgisi kullanmak için uygulamayı etkinleştirin
            // ve üçüncü taraf bir oturum açma sağlayıcıdan oturum açan bir kullanıcı hakkında geçici olarak bilgi depolamak üzere bir tanımlama bilgisi kullanmak için
            // Oturum açma tanımlama bilgisini yapılandırın
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            // Üçüncü taraf bir oturum açma sağlayıcıdan oturum açan bir kullanıcı hakkında geçici olarak bilgi depolamak için bir tanımlama bilgisi kullanın
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Kullanıcı iki öğeli kimlik doğrulama işleminde ikinci öğeyi doğrularken uygulamanın kullanıcı bilgilerini geçici olarak depolamasını sağlar.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Uygulamanın telefon veya e-posta gibi ikinci oturum açma bilgisi doğrulama öğesini anımsamasını sağlar.
            // Bu seçeneği işaretlediğinizde, oturum açma işlemi sırasındaki ikinci doğrulama adımınız oturum açtığınız cihazda anımsanır.
            // Bu, oturum açtığınız sıradaki RememberMe seçeneğine benzer.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Üçüncü taraf oturum açma sağlayıcılarıyla oturum açmayı etkinleştirmek için aşağıdaki satırların açıklamasını kaldırın
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
