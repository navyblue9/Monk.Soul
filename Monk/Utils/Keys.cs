using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monk.Utils
{
    public class Keys
    {
        public const string ConnectionStringKey = "Monk.Soul";
        public static List<string> AccessVerifyAreas = new List<string>()
        {
            "Backend"
        };
        public const string SessionKey = "Monk.Soul.SessionMember";
        public const string SysSetInfoInjectionKey = "SysSetInfo";
        public const string HaviorInfoInjectionKey = "HaviorInfo";
        public const string MemberInfoInjectionKey = "MemberInfo";
        public const string SysSetCacheKey = "SysSetInfo_CacheKey";
        public const string ModuleCacheKey = "Module_CacheKey";
        public const string BackendMenus = "BackendMenus_CacheKey";
    }
}