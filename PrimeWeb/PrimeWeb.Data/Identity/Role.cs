using Microsoft.AspNet.Identity.EntityFramework;
using PrimeWeb.Core.Data;

namespace PrimeWeb.Data.Identity
{
    public class Role: IdentityRole<int, UserRole>, IIdentityEntity
    {
    }
}
