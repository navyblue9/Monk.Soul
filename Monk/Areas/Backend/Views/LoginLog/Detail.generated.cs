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
    using Monk.ViewModels;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Backend/Views/LoginLog/Detail.cshtml")]
    public partial class _Areas_Backend_Views_LoginLog_Detail_cshtml : System.Web.Mvc.WebViewPage<LoginLogVM>
    {
        public _Areas_Backend_Views_LoginLog_Detail_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
  
    ViewBag.Title = "查看日志";
    Layout = "~/Areas/Backend/Views/Shared/_Detail.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("crumbs", () => {

WriteLiteral("\r\n    <label");

WriteLiteral(" class=\"backend-crumbs-separator\"");

WriteLiteral(">/</label>\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" title=\"数据管理\"");

WriteLiteral(">数据管理</a>\r\n    <label");

WriteLiteral(" class=\"backend-crumbs-separator\"");

WriteLiteral(">/</label>\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" title=\"日志管理\"");

WriteLiteral(">日志管理</a>\r\n    <label");

WriteLiteral(" class=\"backend-crumbs-separator\"");

WriteLiteral(">/</label>\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" title=\"查看日志\"");

WriteLiteral(">查看日志</a>\r\n");

});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">登录账号</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 19 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Model.Account);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">登录密码</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 25 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Model.Password);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">登入时间</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 31 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Model.InTime);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">成功登入</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 37 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Html.Raw(DataToHtmlHelper.StatusHtml(Model.Sucessed)));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">退出时间</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 43 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(DataToHtmlHelper.NullHtml(Model.OffTime));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">登录IP</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 49 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Model.IPAddress);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">IP详情</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 55 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(DataToHtmlHelper.NullHtml(Model.IPDetail));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">请求方式</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 61 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Model.HttpMethod);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">异步请求</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 67 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Html.Raw(DataToHtmlHelper.StatusHtml(Model.AjaxRequest)));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">移动设备</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 73 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Html.Raw(DataToHtmlHelper.StatusHtml(Model.MobileDevice)));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">操作系统</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 79 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Model.Platform);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">浏览器类型</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 85 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
   Write(Model.Browser);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");

DefineSection("operate", () => {

WriteLiteral("\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"monk-input-button alizarin\"");

WriteLiteral(" onclick=\"deletes();\"");

WriteLiteral(">删除记录</a>\r\n    <input");

WriteLiteral(" type=\"reset\"");

WriteLiteral(" class=\"monk-input-button peterRiver\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3127), Tuple.Create("\"", 3195)
, Tuple.Create(Tuple.Create("", 3137), Tuple.Create("window.location.href", 3137), true)
, Tuple.Create(Tuple.Create(" ", 3157), Tuple.Create("=", 3158), true)
, Tuple.Create(Tuple.Create(" ", 3159), Tuple.Create("\'", 3160), true)
            
            #line 91 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
              , Tuple.Create(Tuple.Create("", 3161), Tuple.Create<System.Object, System.Int32>(Url.Action("Select","LoginLog")
            
            #line default
            #line hidden
, 3161), false)
, Tuple.Create(Tuple.Create("", 3193), Tuple.Create("\';", 3193), true)
);

WriteLiteral(" value=\"返回列表\"");

WriteLiteral(">\r\n    <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"monk-input-button orange monk-form-previous\"");

WriteLiteral(" value=\"返回前页\"");

WriteLiteral(" onclick=\"history.go(-1);\"");

WriteLiteral(">\r\n");

});

WriteLiteral("\r\n");

DefineSection("foot", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        function deletes() {\r\n            backend.confirm(\"您确定要执行此操作吗？\", null," +
" function (index) {\r\n                backend.post(\"");

            
            #line 99 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
                         Write(Url.Action("Delete","LoginLog",new { }));

            
            #line default
            #line hidden
WriteLiteral("\", { ids: \"");

            
            #line 99 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
                                                                            Write(Model.LogID);

            
            #line default
            #line hidden
WriteLiteral("\" }, function (data) {\r\n                    window.location.href = \"");

            
            #line 100 "..\..\Areas\Backend\Views\LoginLog\Detail.cshtml"
                                       Write(Url.Action("Select","LoginLog"));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n                });\r\n            });\r\n        }\r\n    </script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
