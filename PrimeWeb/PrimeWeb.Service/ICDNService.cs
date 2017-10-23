using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Service
{
    public interface ICDNService
    {
        void Save(byte[] content, string filename, string folder);
        string GetPath(string relativePath);
    }
}
