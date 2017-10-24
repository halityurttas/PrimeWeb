using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Linq;

namespace PrimeWeb.Service.CDNService
{
    public class AzureCDNService : ICDNService
    {

        private ILogService logService;
        private string connectionString;
        private string container;

        public string GetPath(string relativePath)
        {
            try
            {
                var container = getContainer();
                var blob = container.ListBlobs(relativePath).FirstOrDefault(w => w.GetType() == typeof(CloudBlockBlob));
                if (blob != null)
                {
                    return blob.Uri.OriginalString;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logService.Error("CDN Error", ex);
                throw;
            }
        }

        public void Save(byte[] content, string filename, string folder)
        {
            try
            {
                var container = getContainer();
                var block = container.GetBlockBlobReference(folder + "/" + filename);
                block.UploadFromByteArray(content, 0, content.Length);   
            }
            catch (Exception ex)
            {
                logService.Error("CDN Error", ex);
                throw;
            }
        }

        #region Utils

        private CloudBlobContainer getContainer()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(this.container);
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            return container;
        }

        #endregion
    }
}
