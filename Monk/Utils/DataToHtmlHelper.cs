using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monk.Utils
{
    public class DataToHtmlHelper
    {
        public static string StatusHtml(bool flag)
        {
            if (flag) return "<span class=\"monk-iconfont icon-monk-dagou tipcolor\" style=\"background:none;line-height:normal;height:auto;width:auto;\"></span>";
            else return "<span class=\"monk-iconfont icon-monk-dacha\" style=\"background:none;line-height:normal;height:auto;width:auto;\"></span>";
        }

        public static string NullHtml(object str, string result = "无")
        {
            if (str == null || str.ToString().Trim() == "") return result;
            return str.ToString();
        }

        public static string GetIconfont(string iconStr)
        {
            return "<span class=\"monk-iconfont " + iconStr + "\" style=\"background:none;line-height:normal;height:auto;width:auto;\"></span>";
        }
    }
}