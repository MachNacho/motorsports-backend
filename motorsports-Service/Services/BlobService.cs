using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using motorsports_Service.Contracts;

namespace motorsports_Service.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobContainerClient _containerClient;
        public BlobService(IConfiguration config)
        {
            var connectionString = config["AzureBlobStorage:ConnectionString"];
            var containerName = config["AzureBlobStorage:ContainerName"];
            _containerClient = new BlobContainerClient(connectionString, containerName);
            _containerClient.CreateIfNotExists(PublicAccessType.Blob);
        }
        public Task<bool> DeleteAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<(Stream? Content, string? ContentType)> GetFileAsync(string fileName)
        {
            var blobClient = _containerClient.GetBlobClient(fileName);
            var download = await blobClient.DownloadAsync();
            var contentType = download.Value.Details.ContentType ?? "application/octet-stream";
            return (download.Value.Content, contentType);
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var blobClient = _containerClient.GetBlobClient(file.FileName);
            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }
            return blobClient.Uri.ToString();
        }
    }
}
