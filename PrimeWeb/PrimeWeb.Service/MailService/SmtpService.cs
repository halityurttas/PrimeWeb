using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Service.MailService
{
    public class SmtpService: IMailService
    {
        private SmtpClient client;
        private ILogService logService;

        public SmtpService(ILogService logService, string host, int port, string username, string password, bool enableSSL)
        {
            this.logService = logService;
            client = new SmtpClient(host, port);
            client.Credentials = new NetworkCredential(username, password);
            client.EnableSsl = enableSSL;
        }

        public async Task<bool> SendAsync(string from, string fromName, string to, string toName, string subject, string message)
        {
            var fromAddress = new MailAddress(from, fromName);
            var toAddress = new MailAddress(to, toName);
            var mailMessage = new MailMessage(fromAddress, toAddress);
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message;
            try
            {
                await client.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                logService.Error("Mail error", ex);
                return false;
            }
            
        }

        public Task<bool> SendWithTemplateAsync(string from, string fromName, string to, string toName, string subject, string template, Dictionary<string, object> globalVars, Dictionary<string, object> vars)
        {
            throw new NotImplementedException();
        }
        
    }
}
