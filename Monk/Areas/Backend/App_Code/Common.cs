using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Monk.Utils;
using Monk.ViewModels;
using System.Web.Routing;

namespace Monk.Areas.Backend.App_Code
{
    public class Common
    {
        static RESTFul restful = new RESTFul(RESTFul.GetSecretKey(Keys.Access_Token));

        public static string ModuleDropDownList(Guid? selectID = null)
        {
            var clientResult = restful.Get<JsonData<List<V_ModuleVM>>>(RouteHelper.RouteUrl(new { controller = "Module", action = "Modules" }));
            if (clientResult.status == "y")
            {
                var selectHtml = string.Empty;
                CreateModuleDropDownList(clientResult.data, selectID, default(Guid), ref selectHtml);
                return selectHtml;
            }
            else return string.Empty;
        }

        private static void CreateModuleDropDownList(List<V_ModuleVM> list, Guid? selectID, Guid? parentID, ref string selectHTML, int level = 0)
        {
            var querylist = list.Where(u => u.ParentID == parentID).OrderBy(u => u.Sort);
            if (querylist.Count() > 0)
            {
                level++;
                string space = "";
                for (var i = 0; i < level - 1; i++) space += "　";
                foreach (var item in querylist)
                {
                    selectHTML += "<option value='" + item.ModuleID + "' " + (item.ModuleID == selectID ? " selected=\"selected\" " : "") + ">" + space + "├ " + item.Name + "</option>";
                    CreateModuleDropDownList(list, selectID, item.ModuleID, ref selectHTML, level);
                }
            }
            level = 0;
        }
    }
}