using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeWeb.Service
{
    public interface IMailService
    {
        Task<bool> SendAsync(string from, string fromName, string to, string toName, string subject, string message);
        Task<bool> SendWithTemplateAsync(string from, string fromName, string to, string toName, string subject, string template, Dictionary<string, object> globalVars, Dictionary<string, object> vars);
    }
}
