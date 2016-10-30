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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Backend/Views/ServerInfo/Detail.cshtml")]
    public partial class _Areas_Backend_Views_ServerInfo_Detail_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Backend_Views_ServerInfo_Detail_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
  
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

            
            #line 10 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
Write(ViewBag.HaviorInfo.HeadCode);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

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

WriteLiteral(" title=\"缓存管理\"");

WriteLiteral(">缓存管理</a>\r\n    <label");

WriteLiteral(" class=\"backend-crumbs-separator\"");

WriteLiteral(">/</label>\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" title=\"服务器信息\"");

WriteLiteral(">服务器信息</a>\r\n    <label");

WriteLiteral(" class=\"backend-crumbs-separator\"");

WriteLiteral(">/</label>\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" title=\"查看服务器信息\"");

WriteLiteral(">查看服务器信息</a>\r\n");

});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">客户端浏览器信息</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 27 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Request.ServerVariables["HTTP_USER_AGENT"]);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器名称</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 33 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Server.MachineName);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器IP地址</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 39 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Request.ServerVariables["LOCAL_ADDR"]);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器.NET框架版本</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 45 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Environment.Version.ToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器操作系统</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 51 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Environment.OSVersion.ToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器IIS版本</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 57 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Request.ServerVariables["SERVER_SOFTWARE"]);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器域名</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 63 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Request.ServerVariables["SERVER_NAME"]);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器端口</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 69 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Request.ServerVariables["SERVER_PORT"]);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器区域语言</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 75 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"]);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器虚拟目录</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 81 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Request.ServerVariables["APPL_PHYSICAL_PATH"]);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器脚本超时时间</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 87 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Server.ScriptTimeout);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器CPU数量</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 93 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">服务器CPU类型</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 99 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">HTTPS支持情况</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 105 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Request.ServerVariables["HTTPS"]);

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">当前Session总数</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-detail-wrap monk-full\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 111 "..\..\Areas\Backend\Views\ServerInfo\Detail.cshtml"
   Write(Session.Keys.Count.ToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
