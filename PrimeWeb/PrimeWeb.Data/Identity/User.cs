using Microsoft.AspNet.Identity.EntityFramework;
using PrimeWeb.Data.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrimeWeb.Data.Identity
{
    public class User: IdentityUser<int, Login, UserRole, UserClaim>
    {
        public User()
        {
            Contents = new HashSet<Content>();
        }

        public string Title { get; set; }
        public bool Active { get; set; }

        public HashSet<Content> Contents { get; set; }
    }

    
}
