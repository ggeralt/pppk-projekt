using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.Configuration;

namespace BlobStorage.DAO
{
    static class Repository
    {
        private const string ContainerName = "blob";
        //private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static readonly string cs = ConfigurationManager.AppSettings["StorageConnectionString"];

        private static readonly Lazy<BlobContainerClient> container = new Lazy<BlobContainerClient>(() 
            => new BlobServiceClient(cs).GetBlobContainerClient(ContainerName));

        public static BlobContainerClient Container = container.Value;
    }
}
