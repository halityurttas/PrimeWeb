using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWeb.Service.CDNService
{
    public class AmazonCDNService : ICDNService
    {
        private ILogService logService;
        private string accessKey;
        private string secretKey;
        private string bucket;

        public AmazonCDNService(ILogService logService, string accessKey, string secretKey, string bucket)
        {
            this.logService = logService;
            this.accessKey = accessKey;
            this.secretKey = secretKey;
            this.bucket = bucket;
        }

        public string GetPath(string relativePath)
        {
            try
            {
                var amazonS3 = new AmazonS3Client(accessKey, secretKey);
                var bucketResponse = amazonS3.ListBuckets();
                var awsBucket = bucketResponse.Buckets.FirstOrDefault(w => w.BucketName == bucket);
                if (awsBucket == null)
                {
                    return "";
                }
                else
                {
                    return amazonS3.GetPreSignedURL(new GetPreSignedUrlRequest
                    {
                        BucketName = bucket,
                        Key = relativePath,
                        Expires = DateTime.MaxValue
                    });
                }
            }
            catch (Exception ex)
            {
                logService.Error("AmazonS3", ex);
                return "";
            }
        }

        public void Save(byte[] content, string filename, string folder)
        {
            try
            {
                var amazonS3 = new AmazonS3Client(accessKey, secretKey);
                using (var ms = new MemoryStream(content))
                {
                    var transferUtility = new TransferUtility(amazonS3);
                    var transferUtilityRequest = new TransferUtilityUploadRequest()
                    {
                        BucketName = bucket,
                        StorageClass = S3StorageClass.ReducedRedundancy,
                        CannedACL = S3CannedACL.PublicRead,
                        Key = string.IsNullOrEmpty(folder) ? filename : folder.EndsWith("/") ? folder + filename : folder + "/" + filename,
                        InputStream = ms
                    };
                    transferUtility.Upload(transferUtilityRequest);
                }
            }
            catch (Exception ex)
            {
                logService.Error("AmazonS3", ex);
            }
        }
    }
}
