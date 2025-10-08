using Microsoft.Extensions.Caching.Memory;
using motorsports_Domain.Interfaces;

namespace motorsports_Infrastructure.Integration
{
    public class CacheIntegration : ICacheIntegration
    {
        private readonly IMemoryCache _memoryCache;
        public CacheIntegration(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            _memoryCache.TryGetValue(key, out T value);
            return await Task.FromResult(value);
        }

        public Task RemoveAsync(string key)
        {
            _memoryCache.Remove(key);
            return Task.CompletedTask;
        }

        public Task SetAsync<T>(string key, T value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };
            _memoryCache.Set(key, value, cacheEntryOptions);
            return Task.CompletedTask;
        }
    }
}
