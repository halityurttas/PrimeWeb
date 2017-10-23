using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Service.CDNService
{
    public class FileSystemCDNService: ICDNService
    {
        private string path;
        private string vpath;

        public FileSystemCDNService(string path, string vpath)
        {
            this.path = path;
            this.vpath = vpath;
        }

        public string GetPath(string relativePath)
        {
            return (vpath.EndsWith("/") ? vpath : vpath + "/") + relativePath;
        }

        public void Save(byte[] content, string filename, string folder)
        {
            if ()
        }
    }
}
