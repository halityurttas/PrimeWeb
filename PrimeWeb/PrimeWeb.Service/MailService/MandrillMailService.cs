using Mandrill;
using Mandrill.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Service.MailService
{
    public class MandrillMailService: IMailService
    {
        private MandrillApi api;
        private ILogService logService;

        public MandrillMailService(ILogService logService, string apiKey)
        {
            this.logService = logService;
            api = new MandrillApi(apiKey);
        }

        public async Task<bool> SendAsync(string from, string fromName, string to, string toName, string subject, string message)
        {
            try
            {
                var fromAddress = new MandrillMailAddress(from, fromName);
                var toAddress = new MandrillMailAddress(to, toName);
                var mandrillMessage = new MandrillMessage(fromAddress, toAddress);
                var result = await api.Messages.SendAsync(mandrillMessage);
                if (result.Any(w => w.Status == MandrillSendMessageResponseStatus.Invalid || w.Status == MandrillSendMessageResponseStatus.Rejected))
                {
                    logService.Info(result.FirstOrDefault().RejectReason);
                    return false;
                }
                else
                {
                    logService.Info(result.FirstOrDefault().RejectReason);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logService.Error("Mandrill Error", ex);
                return false;
            }

        }

        public Task<bool> SendWithTemplateAsync(string from, string fromName, string to, string toName, string subject, string template, Dictionary<string, object> globalVars, Dictionary<string, object> vars)
        {
            throw new NotImplementedException();
        }
    }
}
