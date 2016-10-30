using System;
using System.Collections.Generic;
using System.Linq;
using Monk.Areas.Backend.ViewModels;

namespace Monk.Areas.Backend.App_Code
{
    public class Common
    {
        public static string ModuleDropDownList(List<V_ModuleVM> list, Guid? selectID = null)
        {
            var selectHtml = string.Empty;
            CreateModuleDropDownList(list, selectID, default(Guid), ref selectHtml);
            return selectHtml;
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