﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Monk;
    using Monk.Areas.Backend.ViewModels;
    using Monk.Utils;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Backend/Views/Tool/GUID.cshtml")]
    public partial class _Areas_Backend_Views_Tool_GUID_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Backend_Views_Tool_GUID_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\Backend\Views\Tool\GUID.cshtml"
  
    ViewBag.Title = ViewBag.HaviorInfo.Name + " - " + ViewBag.SysSetInfo.Name;
    Layout = ViewBag.HaviorInfo.Layout;
    ViewBag.Keywords = ViewBag.SysSetInfo.Keywords;
    ViewBag.Description = ViewBag.SysSetInfo.Description;
    ViewBag.Copyright = ViewBag.SysSetInfo.Copyright;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("head", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 10 "..\..\Areas\Backend\Views\Tool\GUID.cshtml"
Write(Html.Raw(ViewBag.HaviorInfo.HeadCode));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

DefineSection("crumbs", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 14 "..\..\Areas\Backend\Views\Tool\GUID.cshtml"
Write(Html.Raw(ViewBag.HaviorInfo.Crumbs));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">GUID</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-right icon-monk-input\"");

WriteLiteral("></span>\r\n        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"monk-form-input large\"");

WriteLiteral(" readonly=\"readonly\"");

WriteLiteral(" placeholder=\"请输入...\"");

WriteAttribute("value", Tuple.Create(" value=\"", 718), Tuple.Create("\"", 739)
            
            #line 21 "..\..\Areas\Backend\Views\Tool\GUID.cshtml"
                          , Tuple.Create(Tuple.Create("", 726), Tuple.Create<System.Object, System.Int32>(ViewBag.GUID
            
            #line default
            #line hidden
, 726), false)
);

WriteLiteral(" />\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">通常生成的GUID码是唯一的，请放心使用。</div>\r\n</div>\r\n\r\n");

DefineSection("operate", () => {

WriteLiteral("\r\n    <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"monk-input-button turquoise monk-form-submit\"");

WriteLiteral(" value=\"重新生成\"");

WriteLiteral(" onclick=\"window.location.reload();\"");

WriteLiteral(">\r\n");

});

WriteLiteral("\r\n");

DefineSection("foot", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 31 "..\..\Areas\Backend\Views\Tool\GUID.cshtml"
Write(Html.Raw(ViewBag.HaviorInfo.FootCode));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
