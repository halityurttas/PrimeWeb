using PrimeWeb.Util.Network;
using System.IO;

namespace PrimeWeb.Service.CDNService
{
    public class NetworkDiskCDNService : ICDNService
    {

        private ILogService logService;
        private string vpath;
        private string path;
        private string username;
        private string password;

        public NetworkDiskCDNService(ILogService logService, string vpath, string path, string username, string password)
        {
            this.logService = logService;
            this.vpath = vpath;
            this.path = path;
            this.username = username;
            this.password = password;
        }

        public string GetPath(string relativePath)
        {
            return (vpath.EndsWith("/") ? vpath : vpath + "/") + relativePath;
        }

        public void Save(byte[] content, string filename, string folder)
        {
            using (new NetworkConnection(path, new System.Net.NetworkCredential(username, password)))
            {
                string netpath = Path.Combine(path, folder, filename);
                using (FileStream fs = new FileStream(netpath, FileMode.Create))
                {
                    fs.Write(content, 0, content.Length);
                }
            }
        }
    }
}
