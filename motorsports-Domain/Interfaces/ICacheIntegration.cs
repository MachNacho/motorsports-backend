﻿namespace motorsports_Domain.Interfaces
{
    public interface ICacheIntegration
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value);
        Task RemoveAsync(string key);
    }
}
