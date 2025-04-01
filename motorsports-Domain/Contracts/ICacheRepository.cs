namespace motorsports_Domain.Contracts
{
    public interface ICacheRepository
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value);
        Task RemoveAsync(string key);
    }
}
