using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PrimeWeb.Data.Identity;
using PrimeWeb.Framework.Config;
using System;
using System.Web;

namespace PrimeWeb.App.WebForm.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword<User, int>(User.Identity.GetUserId<int>());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber<User, int>(User.Identity.GetUserId<int>()));

            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled<User, int>(User.Identity.GetUserId<int>());

            LoginsCount = manager.GetLogins<User, int>(User.Identity.GetUserId<int>()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                var message = Request.QueryString["m"];
                if (message != null)
                {
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Parolanız değiştirildi."
                        : message == "SetPwdSuccess" ? "Parolanız ayarlandı."
                        : message == "RemoveLoginSuccess" ? "Hesap kaldırıldı."
                        : message == "AddPhoneNumberSuccess" ? "Telefon numarası eklendi"
                        : message == "RemovePhoneNumberSuccess" ? "Telefon numarası kaldırıldı"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var user = manager.FindById<User, int>(User.Identity.GetUserId<int>());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled<User, int>(User.Identity.GetUserId<int>(), false);

            Response.Redirect("/Account/Manage");
        }

        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled<User, int>(User.Identity.GetUserId<int>(), true);

            Response.Redirect("/Account/Manage");
        }
    }
}