using System;
using System.Threading.Tasks;

namespace EasyTemplateCore.Web.RedisCache
{
    public interface ICacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
