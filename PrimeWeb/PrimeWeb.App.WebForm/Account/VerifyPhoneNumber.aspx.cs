using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PrimeWeb.Data.Identity;
using PrimeWeb.Framework.Config;
using System;
using System.Web;

namespace PrimeWeb.App.WebForm.Account
{
    public partial class VerifyPhoneNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var phonenumber = Request.QueryString["PhoneNumber"];
            var code = manager.GenerateChangePhoneNumberToken<User, int>(User.Identity.GetUserId<int>(), phonenumber);           
            PhoneNumber.Value = phonenumber;
        }

        protected void Code_Click(object sender, EventArgs e)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Geçersiz kod");
                return;
            }

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var result = manager.ChangePhoneNumber<User, int>(User.Identity.GetUserId<int>(), PhoneNumber.Value, Code.Text);

            if (result.Succeeded)
            {
                var user = manager.FindById<User, int>(User.Identity.GetUserId<int>());

                if (user != null)
                {
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    Response.Redirect("/Account/Manage?m=AddPhoneNumberSuccess");
                }
            }

            ModelState.AddModelError("", "Telefon doğrulanamadı");
        }
    }
}