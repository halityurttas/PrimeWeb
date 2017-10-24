using System;
using System.IO;

namespace PrimeWeb.Service.CDNService
{
    public class FileSystemCDNService: ICDNService
    {
        private string path;
        private string vpath;
        ILogService logService;

        public FileSystemCDNService(ILogService logService, string path, string vpath)
        {
            this.logService = logService;
            this.path = path;
            this.vpath = vpath;
        }

        public string GetPath(string relativePath)
        {
            return (vpath.EndsWith("/") ? vpath : vpath + "/") + relativePath;
        }

        public void Save(byte[] content, string filename, string folder)
        {
            if (!File.Exists(Path.Combine(path, folder, filename)))
            {
                try
                {
                    using (FileStream fs = new FileStream(Path.Combine(path, folder, filename), FileMode.CreateNew))
                    {
                        fs.Write(content, 0, content.Length);
                    }
                }
                catch (Exception ex)
                {
                    logService.Error("File write error.", ex);
                    throw;
                }
            }
            else
            {
                logService.Warn("File already exists!", new Exception(Path.Combine(path, folder, filename)));
                throw new InvalidOperationException("File already exists!");
            }
        }
    }
}
