using Microsoft.Extensions.Caching.Memory;

namespace _19_AspNetCore.CacheSample.Extensions;

public class MyMemoryCache : IMemoryCache
{
	private readonly MemoryCache _memoryCache;

	public MyMemoryCache()
	{
		_memoryCache = new MemoryCache(new MemoryCacheOptions
		{
			// 超过最大大小时压缩缓存的量。
			CompactionPercentage = 0,

			// 缓存的大小限制
			SizeLimit = 1024,

			// 过期扫描频率
			ExpirationScanFrequency = System.TimeSpan.FromHours(1)
		});
	}

	public ICacheEntry CreateEntry(object key)
	{
		return _memoryCache.CreateEntry(key);
	}

	public void Dispose()
	{
		_memoryCache.Dispose();
	}

	public void Remove(object key)
	{
		_memoryCache.Remove(key);
	}

	public bool TryGetValue(object key, out object value)
	{
		return _memoryCache.TryGetValue(key, out value);
	}
}