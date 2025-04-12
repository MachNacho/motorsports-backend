using Microsoft.AspNetCore.Http;

namespace motorsports_Service.Contracts
{
    public interface IBlobService
    {
        Task<string> UploadAsync(IFormFile file);
        Task<(Stream? Content, string? ContentType)> GetFileAsync(string fileName);
        Task<bool> DeleteAsync(string fileName);
    }
}