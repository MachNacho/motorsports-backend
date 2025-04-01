using Microsoft.Extensions.Caching.Memory;
using motorsports_Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Infrastructure.Repositories
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        public MemoryCacheService(IMemoryCache cache)
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
            return Task.CompletedTask;
        }

        public Task SetAsync<T>(string key, T value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            };
            _cache.Set(key, value, cacheEntryOptions);
            return Task.CompletedTask;
        }
    }
}
