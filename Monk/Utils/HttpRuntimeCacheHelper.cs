using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Monk.Utils
{
    public class HttpRuntimeCacheHelper
    {
        public static T Get<T>(string key) where T : new()
        {
            return (T)HttpRuntime.Cache.Get(key);
        }

        public static void Set(string key, object value)
        {
            Set(key, value, null, DateTime.UtcNow.AddYears(1), Cache.NoSlidingExpiration);
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