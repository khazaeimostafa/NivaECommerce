using Microsoft.Extensions.Options;
using OrderService.Application.Common.Interfaces;
using OrderService.Infrastructure.Shared.Configuration.RedisConfigs;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Shared.RedisService;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _redis;
    private readonly RedisCacheOptions _options;

    public RedisCacheService(IConnectionMultiplexer redis, IOptions<RedisCacheOptions> options)
    {
        _redis=redis.GetDatabase();
        _options=options.Value;
    }

    public async Task SetAsync<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value);
        await _redis.StringSetAsync(key, json, TimeSpan.FromMinutes(_options.DefaultTTLMinutes));
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var json = await _redis.StringGetAsync(key);
        if (json.HasValue)
            await _redis.KeyExpireAsync(key, TimeSpan.FromMinutes(_options.SlidingTTLMinutes));

        return json.HasValue ? JsonSerializer.Deserialize<T>(json!) : default;
    }

    public async Task RemoveAsync(string key) => await _redis.KeyDeleteAsync(key);



}
