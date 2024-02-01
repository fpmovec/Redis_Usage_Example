using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Redis_Usage_Example.Models;

namespace Redis_Usage_Example.Services;

public class CacheService(IDistributedCache distributedCache) : ICacheService
{
    private IDistributedCache _distributedCache = distributedCache;
    
    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        var data = await _distributedCache.GetStringAsync(key, cancellationToken);

        if (string.IsNullOrEmpty(data))
        {
            throw new NullReferenceException();
        }

        return JsonConvert.DeserializeObject<T>(data);
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
    {
        string dataString = JsonConvert.SerializeObject(value);

        await _distributedCache.SetStringAsync(key, dataString, cancellationToken);
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}