using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using motorsports_Domain.Interfaces;

namespace motorsports_Infrastructure.Integration
{
    public class BlobIntegration : IBlobIntegration
    {
        private readonly BlobContainerClient _containerClient;
        public BlobIntegration(IConfiguration config)
        {
            var keyVaultUrl = config["KeyVault:Url"];
            var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            var connectionString = secretClient.GetSecret("BlobStorageConnectionString");
            var containerName = secretClient.GetSecret("BlobContainerName");

            _containerClient = new BlobContainerClient(connectionString.Value.Value, containerName.Value.Value);
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
