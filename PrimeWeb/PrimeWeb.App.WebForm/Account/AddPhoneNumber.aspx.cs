using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PrimeWeb.Data.Identity;
using PrimeWeb.Framework.Config;
using System;
using System.Web;

namespace PrimeWeb.App.WebForm.Account
{
    public partial class AddPhoneNumber : System.Web.UI.Page
    {
        protected void PhoneNumber_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var code = manager.GenerateChangePhoneNumberToken<User, int>(User.Identity.GetUserId<int>(), PhoneNumber.Text);
            if (manager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = PhoneNumber.Text,
                    Body = "Güvenlik kodunuz " + code
                };

                manager.SmsService.Send(message);
            }

            Response.Redirect("/Account/VerifyPhoneNumber?PhoneNumber=" + HttpUtility.UrlEncode(PhoneNumber.Text));
        }
    }
}