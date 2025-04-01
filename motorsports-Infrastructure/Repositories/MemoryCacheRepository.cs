using Microsoft.Extensions.Caching.Memory;
using motorsports_Domain.Contracts;
namespace motorsports_Infrastructure.Repositories
{
    public class MemoryCacheRepository : ICacheRepository
    {
        private readonly IMemoryCache _cache;
        public MemoryCacheRepository(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<T?> GetAsync<T>(string key)
        {
            _cache.TryGetValue(key, out T value);
            return await Task.FromResult(value);
        }

        public Task RemoveAsync(string key)
        {
            _cache.Remove(key);
            Console.WriteLine("CACHE CLEARED");
            return Task.CompletedTask;
        }

        public Task SetAsync<T>(string key, T value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };
            _cache.Set(key, value, cacheEntryOptions);
            return Task.CompletedTask;
        }
    }
}
