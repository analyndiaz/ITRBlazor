using Evolve.ITR.ServiceContract.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace ITRBlazorWeb.Services
{
    public class DbResultCacheService : IDbResultCacheService
    {
        private readonly IMemoryCache _memoryCache;
        public DbResultCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetDataForQuery<T>(string query)
        {
            if (_memoryCache.TryGetValue(query, out T cacheValue))
            {
                return cacheValue;
            }

            return default;
        }

        public void StoreDataForQuery<T>(string query, T data, TimeSpan? ttl)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                                        .SetSlidingExpiration(TimeSpan.FromSeconds(3));
            _memoryCache.Set(query, data, cacheEntryOptions);
        }
    }
}
