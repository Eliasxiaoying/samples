using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace _19_AspNetCore.CacheSample.Extensions
{
    public static class DistribuedCacheExtensions
    {
        public static async Task<string> GetOrCreateStringAsync(this IDistributedCache _distributedCache, string key, Func<DistributedCacheEntryOptions, string> factory)
        {
			var value = await _distributedCache.GetStringAsync(key);

			if (value == null)
			{
				var option = new DistributedCacheEntryOptions();
				value = factory(option);
				_ = _distributedCache.SetStringAsync(key, value, option);
			}

			return value;
		}
    }
}
