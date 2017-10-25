using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Service.CDNService
{
    public class AmazonCDNService : ICDNService
    {
        private ILogService logService;

        public string GetPath(string relativePath)
        {
            throw new NotImplementedException();
        }

        public void Save(byte[] content, string filename, string folder)
        {
            throw new NotImplementedException();
        }
    }
}
