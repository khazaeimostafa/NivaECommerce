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

        public RedisTestController(ICacheService redisCacheService)
        {
            _redisCacheService=redisCacheService;
        }

        [HttpGet("Set")]
        public async Task<IActionResult> Set()
        {
            await _redisCacheService.SetAsync("Hello", "World");
            return Ok("Key Set");
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var value = await _redisCacheService.GetAsync<string>("Hello");

            return Ok(value);
        }

    }
}
