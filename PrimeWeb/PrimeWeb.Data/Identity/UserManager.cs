using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace PrimeWeb.Data.Identity
{
    public class UserManager : UserManager<User, int>
    {
        public UserManager(IUserStore<User, int> store) : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {

        }
    }
}
