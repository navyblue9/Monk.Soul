using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monk.Utils
{
    public class Keys
    {
        public const string ConnectionStringKey = "Monk.Soul";
        public static List<string> AuthorizeArea = new List<string>()
        {
            "Backend",
            "Services"
        };
        public const string SessionKey = "Monk.Soul.SessionMember";
        public const string SysSetCacheKey = "SysSetInfo_CacheKey";
        public const string Access_Token = "C2A6315748D51DBB521F34D7533AE1CE";
    }
}