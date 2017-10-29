using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace PrimeWeb.Framework.Config
{
    public class ApplicationUserManagerEmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {

            return Task.FromResult(0);
        }
    }
}
