using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace PrimeWeb.Data.Identity
{
    public class User: IdentityUser<int, Login, UserRole, UserClaim>
    {
        public ClaimsIdentity GetClaimsIdentity()
    }

    
}
