using Microsoft.AspNetCore.Http;

namespace motorsports_Domain.Interfaces
{
    public interface IBlobIntegration
    {
        Task<string> UploadAsync(IFormFile file);
        Task<(Stream? Content, string? ContentType)> GetFileAsync(string fileName);
        Task<bool> DeleteAsync(string fileName);
    }
}
