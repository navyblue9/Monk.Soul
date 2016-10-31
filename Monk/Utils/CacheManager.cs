using System;
using System.Web;
using System.Web.Caching;

namespace Monk.Utils
{
    public class CacheManager
    {
        public static T Get<T>(string key) where T : new()
        {
            return (T)HttpRuntime.Cache.Get(key);
        }

        public static bool Contains(string key)
        {
            return HttpRuntime.Cache.Get(key) != null;
        }

        public static void Set(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        public static void Set(string key, object value, CacheDependency dependencies)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies);
        }

        public static void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies, absoluteExpiration, slidingExpiration);
        }

        public static void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
    }
}