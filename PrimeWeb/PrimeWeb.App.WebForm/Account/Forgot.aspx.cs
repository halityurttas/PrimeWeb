using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using PrimeWeb.App.WebForm.Models;

namespace PrimeWeb.App.WebForm.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Kullanıcının e-posta adresini doğrulayın
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindByName(Email.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    FailureText.Text = "Kullanıcı yok veya doğrulanmamış.";
                    ErrorMessage.Visible = true;
                    return;
                }
                // Hesap onayını ve parola sıfırlamayı etkinleştirme hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkID=320771 adresini ziyaret edin.
                // Kodu ve parola sıfırlama sayfasına yönlendirmeyi içeren e-posta gönderin
                //string code = manager.GeneratePasswordResetToken(user.Id);
                //string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
                //manager.SendEmail(user.Id, "Parola Sıfırlama", "Lütfen parolanızı sıfırlamak için <a href=\"" + callbackUrl + "\">buraya tıklayın</a>.");
                loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }
    }
}