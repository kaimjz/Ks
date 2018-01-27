using System;

namespace Infrastructure.Cache
{
    public abstract class ICacheProvider : IDisposable
    {
        /// <summary>
        /// 缓存组件
        /// </summary>
        protected ICacheContext CacheContext { get; private set; }

        /// <summary>
        /// 动态设置缓存组件
        /// </summary>
        /// <param name="cacheContext"></param>
        protected void SetInstance(ICacheContext cacheContext)
        {
            if (CacheContext != null)
            {
                CacheContext = null;
            }
            //初始化缓存组件
            CacheContext = cacheContext;
        }

        public void Dispose()
        {
        }
    }
}