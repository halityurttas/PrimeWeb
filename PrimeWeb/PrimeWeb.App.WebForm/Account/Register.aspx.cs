using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PrimeWeb.Data.Identity;
using PrimeWeb.Framework.Config;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PrimeWeb.App.WebForm.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new User() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Hesabınızı onaylayın", "Lütfen hesabınızı onaylamak için <a href=\"" + callbackUrl + "\">buraya tıklayın</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}