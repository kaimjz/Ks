using System;

namespace Infrastructure.Cache
{
    public class CacheProvider<T> : ICacheProvider
    {
        public CacheProvider()
        {
            SetInstance(new CacheContext());
        }

        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <typeparam name="T">缓存对象类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>缓存对象</returns>
        public bool CreateCache(string key, T entity, DateTime expire)
        {
            return CacheContext.Set<T>(key, entity, expire);
        }

        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <typeparam name="T">缓存对象类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>缓存对象</returns>
        public T GetCache(string key)
        {
            return CacheContext.Get<T>(key);
        }

        /// <summary>
        /// 移除一个缓存项
        /// </summary>
        /// <param name="key">缓存项key</param>
        /// <returns>true成功,false失败</returns>
        public bool RemoveCache(string key)
        {
            return CacheContext.Remove<T>(key);
        }
    }
}