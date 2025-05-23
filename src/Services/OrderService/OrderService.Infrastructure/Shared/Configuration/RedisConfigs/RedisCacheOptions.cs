using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Shared.Configuration.RedisConfigs
{
    public class RedisCacheOptions
    {
        public int DefaultTTLMinutes { get; set; }
        public int SlidingTTLMinutes { get; set; }
    }
}
