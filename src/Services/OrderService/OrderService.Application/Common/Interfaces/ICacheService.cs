using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Common.Interfaces
{
    public interface ICacheService
    {
        Task SetAsync<T>(string key, T value);
        Task<T?> GetAsync<T>(string key);
        Task RemoveAsync(string key);
    }
    public interface IHasheService
    {
        Task SetHashAsync(string key, Dictionary<string, string> values);
        Task<Dictionary<string, string>> GetHashAsync(string key);
    }
}
