using System;
using System.Web;

namespace Infrastructure.Cache
{
    internal class CacheContext : ICacheContext
    {
        private readonly System.Web.Caching.Cache _objCache = HttpRuntime.Cache;

        public override bool Set<T>(string key, T entity, DateTime expire)
        {
            var obj = Get<T>(key);
            if (obj != null)
            {
                Remove<T>(key);
            }
            _objCache.Insert(key, entity, null, expire, System.Web.Caching.Cache.NoSlidingExpiration);
            return true;
        }

        public override bool Remove<T>(string key)
        {
            _objCache.Remove(key);
            return true;
        }

        public override T Get<T>(string key)
        {
            return (T)_objCache[key];
        }
    }
}