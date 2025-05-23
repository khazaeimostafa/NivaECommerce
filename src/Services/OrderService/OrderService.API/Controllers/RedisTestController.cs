using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Common.Interfaces;
using OrderService.Infrastructure.Shared.RedisService;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisTestController : ControllerBase
    {
        private readonly ICacheService _redisCacheService;
        private readonly IHasheService _redisHashService;

        public RedisTestController(ICacheService redisCacheService, IHasheService redisHashService)
        {
            _redisCacheService=redisCacheService;
            _redisHashService=redisHashService;
        }

        [HttpGet("Set")]
        public async Task<IActionResult> Set([FromQuery] string key, [FromQuery] string value)
        {
            await _redisCacheService.SetAsync(key, value);
            return Ok("Key Set");
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] string key)
        {
            var value = await _redisCacheService.GetAsync<string>(key);

            return Ok(value);
        }


        [HttpGet("hash/set")]
        public async Task<IActionResult> SetHash()
        {
            var user = new Dictionary<string, string>
    {
        { "name", "Navina" },
        { "role", "AlphaDev" }
    };
            await _redisHashService.SetHashAsync("user:1", user);
            return Ok("Hash set");
        }


        [HttpGet("hash/set2")]
        public async Task<IActionResult> Set2Hash()
        {
            var user = new Dictionary<string, string>
    {
        { "mail", "MyMail@gmail.com" },
        { "Mobile", "09919892562" }
    };
            await _redisHashService.SetHashAsync("user:1:profile", user);
            return Ok("Hash set");
        }

        [HttpGet("hash/get")]
        public async Task<IActionResult> GetHash()
        {
            var data = await _redisHashService.GetHashAsync("user:1");
            return Ok(data);
        }


    }
}
