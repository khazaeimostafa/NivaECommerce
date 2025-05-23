using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Common.Interfaces;
using OrderService.Infrastructure.Shared.Configuration.RedisConfigs;
using OrderService.Infrastructure.Shared.RedisService;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.DependencyInjection
{
    public static class RedisServiceRegistration
    {
        public static IServiceCollection AddRedisCaching(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConfig = configuration.GetConnectionString("Redis") ?? "localhost:6379";
            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConfig));
            services.AddScoped<ICacheService, RedisCacheService>();
            services.AddScoped<IHasheService, HasheService>();
            services.Configure<RedisCacheOptions>(configuration.GetSection("RedisCacheOptions"));
            return services;
        }

    }
}
