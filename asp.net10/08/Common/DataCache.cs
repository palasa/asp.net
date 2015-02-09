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
		/// 获取当前应用程序指定CacheKey的Cache�?
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public static object GetCache(string CacheKey)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			return objCache[CacheKey];
		}

		/// <summary>
		/// 设置当前应用程序指定CacheKey的Cache�?
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject);
		}

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache�?
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
        /// ��ӻ����ļ��Ļ�����������
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
        /// ��ӻ��� SQL �������������
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
