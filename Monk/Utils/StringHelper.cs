using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monk.Utils
{
    public class StringHelper
    {
        private static string ReplaceStrToAsterisk(int length)
        {
            var rd = new Random();
            var rdNum = rd.Next(0, 3);
            var asterisk = string.Empty;
            for (int i = 0; i < length + rdNum; i++)
            {
                if (i % 2 == 0) asterisk += "*";
                else if (i % 3 == 0) asterisk += "#";
                else if (i % 4 == 0) asterisk += "&";
                else if (i % 5 == 0) asterisk += "$";
                else asterisk += "@";
            }
            return asterisk;
        }
        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return password;
            if (password.Length <= 6)
            {
                var startTwoWorld = password.Substring(0, 1);
                var endTwoWorld = password.Substring(password.Length - 1, 1);
                return startTwoWorld + ReplaceStrToAsterisk(password.Length - 2) + endTwoWorld;
            }
            else
            {
                var startTwoWorld = password.Substring(0, 2);
                var endTwoWorld = password.Substring(password.Length - 2, 2);
                return startTwoWorld + ReplaceStrToAsterisk(password.Length - 4) + endTwoWorld;
            }
        }
    }
}