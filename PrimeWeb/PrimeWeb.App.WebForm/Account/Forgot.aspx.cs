using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PrimeWeb.Data.Identity;
using PrimeWeb.Framework.Config;
using System;
using System.Web;
using System.Web.UI;

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
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                User user = manager.FindByName(Email.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    FailureText.Text = "Kullanıcı yok veya doğrulanmamış.";
                    ErrorMessage.Visible = true;
                    return;
                }
                //string code = manager.GeneratePasswordResetToken(user.Id);
                //string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
                //manager.SendEmail(user.Id, "Parola Sıfırlama", "Lütfen parolanızı sıfırlamak için <a href=\"" + callbackUrl + "\">buraya tıklayın</a>.");
                loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }
    }
}