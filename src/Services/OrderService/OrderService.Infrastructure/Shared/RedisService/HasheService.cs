using Microsoft.EntityFrameworkCore.Storage;
using OrderService.Application.Common.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Shared.RedisService
{
    public class HasheService : IHasheService
    {


        private readonly StackExchange.Redis.IDatabase _redis;


        public HasheService(IConnectionMultiplexer redis)
        {
            _redis=redis.GetDatabase();
        }

        public async Task SetHashAsync(string key, Dictionary<string, string> values)
        {
            var enteries = values.Select(x => new HashEntry(x.Key, x.Value)).ToArray();
            await _redis.HashSetAsync(key, enteries);
        }

        public async Task<Dictionary<string, string>> GetHashAsync(string key)
        {
            var enteries = await _redis.HashGetAllAsync(key);
            return enteries.ToDictionary(x => x.Name.ToString(), x => x.Value.ToString());
        }


    }
}
