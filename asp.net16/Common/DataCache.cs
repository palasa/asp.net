using System;
using System.Web;
using System.Web.Caching;

namespace Common
{
    public class DataCache
    {
         static bool itemRemoved = false;
         static CacheItemRemovedReason reason;
         CacheItemRemovedCallback onRemove = null;
        /// <summary>
		/// 鑾峰彇褰撳墠搴旂敤绋嬪簭鎸囧畾CacheKey鐨凜ache鍊?
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public static object GetCache(string CacheKey)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			return objCache[CacheKey];
		}

		/// <summary>
		/// 璁剧疆褰撳墠搴旂敤绋嬪簭鎸囧畾CacheKey鐨凜ache鍊?
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject);
		}

        /// <summary>
        /// 璁剧疆褰撳墠搴旂敤绋嬪簭鎸囧畾CacheKey鐨凜ache鍊?
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
		public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration,TimeSpan slidingExpiration )
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject,null,absoluteExpiration,slidingExpiration);
		}

        /// <summary>
        /// 填加基于文件的缓存依赖对象
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="cd"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        public static void SetCache(string CacheKey, object objObject,System.Web.Caching.CacheDependency cd,DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, cd, absoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 填加基于 SQL 缓存的依赖对象
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="cd"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        public static void SetCache(string CacheKey, object objObject, System.Web.Caching.SqlCacheDependency cd, DateTime absoluteExpiration, TimeSpan slidingExpiration,CacheItemRemovedCallback onRemove)
        {
            onRemove = new CacheItemRemovedCallback(RemovedCallback);

            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, cd, absoluteExpiration, slidingExpiration,CacheItemPriority.High,onRemove);
        }

        public static void RemoveCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Remove(CacheKey);
        }

        public static void SetCacheByFileDependency(string CacheKey, object objObject, System.Web.Caching.CacheDependency cd, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            CacheItemRemovedCallback onRemove = new CacheItemRemovedCallback(RemovedCallback);

            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, cd, absoluteExpiration, slidingExpiration, CacheItemPriority.High, onRemove);
        }


        public static void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
           itemRemoved = true;
           reason = r;
        }

    }
}
