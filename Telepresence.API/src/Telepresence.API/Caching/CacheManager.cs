using System;
using Microsoft.Extensions.Caching.Memory;

namespace Telepresence.API.Caching
{
    public static class CacheManager
    {
        public static T GetOrAdd<T>(this IMemoryCache cache, string key, TimeSpan timeToExpire, Func<T> setter)
        {
            var cacheValue = cache.Get<T>(key);
            if (cacheValue != null) return cacheValue;

            var value = setter();

            if (value == null)
                return default(T);

            cache.Set(key, value, new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = timeToExpire,
            });

            return value;
        }
    }
}
