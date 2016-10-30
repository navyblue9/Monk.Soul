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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Backend/Views/Havior/Select.cshtml")]
    public partial class _Areas_Backend_Views_Havior_Select_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Backend_Views_Havior_Select_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\Backend\Views\Havior\Select.cshtml"
  
    ViewBag.Title = "登录日志";
    Layout = "~/Areas/Backend/Views/Shared/_List.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("crumbs", () => {

WriteLiteral("\r\n    <label");

WriteLiteral(" class=\"backend-crumbs-separator\"");

WriteLiteral(">/</label>\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" title=\"系统管理\"");

WriteLiteral(">系统管理</a>\r\n    <label");

WriteLiteral(" class=\"backend-crumbs-separator\"");

WriteLiteral(">/</label>\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" title=\"模块管理\"");

WriteLiteral(">模块管理</a>\r\n    <label");

WriteLiteral(" class=\"backend-crumbs-separator\"");

WriteLiteral(">/</label>\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" title=\"行为管理\"");

WriteLiteral(">行为管理</a>\r\n    <label");

WriteLiteral(" class=\"backend-crumbs-separator\"");

WriteLiteral(">/</label>\r\n    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" title=\"行为列表\"");

WriteLiteral(">行为列表</a>\r\n");

});

WriteLiteral("\r\n");

DefineSection("buttons", () => {

WriteLiteral("\r\n    <span");

WriteLiteral(" class=\"list-btn\"");

WriteLiteral(" onclick=\"backend.checkall(this);\"");

WriteLiteral("><i");

WriteLiteral(" class=\"monk-iconfont icon-backend-quanxuan\"");

WriteLiteral("></i><label>全选</label></span>\r\n    <span");

WriteLiteral(" class=\"list-btn\"");

WriteLiteral(" onclick=\"insert();\"");

WriteLiteral("><i");

WriteLiteral(" class=\"monk-iconfont icon-backend-insert\"");

WriteLiteral("></i><label>新增</label></span>\r\n    <span");

WriteLiteral(" class=\"list-btn\"");

WriteLiteral(" onclick=\"detail(this);\"");

WriteLiteral("><i");

WriteLiteral(" class=\"monk-iconfont icon-backend-details\"");

WriteLiteral("></i><label>查看</label></span>\r\n    <span");

WriteLiteral(" class=\"list-btn\"");

WriteLiteral(" onclick=\"update(this);\"");

WriteLiteral("><i");

WriteLiteral(" class=\"monk-iconfont icon-backend-update\"");

WriteLiteral("></i><label>编辑</label></span>\r\n    <span");

WriteLiteral(" class=\"list-btn\"");

WriteLiteral(" onclick=\"deletes(this);\"");

WriteLiteral("><i");

WriteLiteral(" class=\"monk-iconfont icon-backend-delete\"");

WriteLiteral("></i><label>删除</label></span>\r\n    <span");

WriteLiteral(" class=\"list-btn float-right search-btn\"");

WriteLiteral(" onclick=\"backend.openSearch()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"monk-iconfont icon-backend-search-list\"");

WriteLiteral("></i><label>搜索</label></span>\r\n");

});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"monk-table\"");

WriteLiteral(">\r\n    <table>\r\n        <thead>\r\n            <tr>\r\n                <th");

WriteLiteral(" align=\"center\"");

WriteLiteral(" class=\"monk-table-status\"");

WriteLiteral(">\r\n                    选择\r\n                </th>\r\n                <th");

WriteLiteral(" align=\"left\"");

WriteLiteral(" width=\"10%\"");

WriteLiteral(">\r\n                    名称\r\n                </th>\r\n                <th");

WriteLiteral(" align=\"left\"");

WriteLiteral(">\r\n                    链接地址\r\n                </th>\r\n                <th");

WriteLiteral(" align=\"left\"");

WriteLiteral(">\r\n                    布局地址\r\n                </th>\r\n                <th");

WriteLiteral(" align=\"left\"");

WriteLiteral(" width=\"10%\"");

WriteLiteral(">\r\n                    所属栏目\r\n                </th>\r\n                <th");

WriteLiteral(" align=\"center\"");

WriteLiteral(" class=\"monk-table-status\"");

WriteLiteral(">\r\n                    方式\r\n                </th>\r\n                <th");

WriteLiteral(" align=\"center\"");

WriteLiteral(" class=\"monk-table-status\"");

WriteLiteral(">\r\n                    路由\r\n                </th>\r\n                <th");

WriteLiteral(" align=\"center\"");

WriteLiteral(" class=\"monk-table-status\"");

WriteLiteral(">\r\n                    首页\r\n                </th>\r\n                <th");

WriteLiteral(" align=\"center\"");

WriteLiteral(" class=\"monk-table-status\"");

WriteLiteral(">\r\n                    开放\r\n                </th>\r\n                <th");

WriteLiteral(" align=\"center\"");

WriteLiteral(" class=\"monk-table-status\"");

WriteLiteral(">\r\n                    默认\r\n                </th>\r\n            </tr>\r\n        </th" +
"ead>\r\n        <tbody></tbody>\r\n        <tfoot>\r\n        </tfoot>\r\n    </table>\r\n" +
"</div>\r\n\r\n\r\n");

DefineSection("operate", () => {

WriteLiteral("\r\n    <div");

WriteLiteral(" id=\"page\"");

WriteLiteral(" class=\"m-pagination\"");

WriteLiteral("></div>\r\n");

});

WriteLiteral("\r\n");

DefineSection("foot", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        function insert() {\r\n            var ids = backend.getCheckIds();\r\n   " +
"         if (ids.length > 0) {\r\n                window.location.href = \"");

            
            #line 78 "..\..\Areas\Backend\Views\Havior\Select.cshtml"
                                   Write(Url.Action("Insert", "Havior"));

            
            #line default
            #line hidden
WriteLiteral("/\" + ids[0];\r\n            }\r\n            else {\r\n                window.location." +
"href = \"");

            
            #line 81 "..\..\Areas\Backend\Views\Havior\Select.cshtml"
                                   Write(Url.Action("Insert", "Havior"));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            }\r\n        }\r\n        function detail(){\r\n            var ids=bac" +
"kend.getCheckIds();\r\n            if(ids.length==1){\r\n                window.loca" +
"tion.href=\"");

            
            #line 87 "..\..\Areas\Backend\Views\Havior\Select.cshtml"
                                 Write(Url.Action("Detail","Havior",new { }));

            
            #line default
            #line hidden
WriteLiteral(@"/""+ids[0];
            }
            else{
                backend.Tip(""只能选择一条数据进行操作"");
            }
        }
        function update() {
            var ids = backend.getCheckIds();
            if (ids.length == 1) {
                window.location.href = """);

            
            #line 96 "..\..\Areas\Backend\Views\Havior\Select.cshtml"
                                   Write(Url.Action("Update", "Havior", new { }));

            
            #line default
            #line hidden
WriteLiteral(@"/"" + ids[0];
            }
            else {
                backend.Tip(""只能选择一条数据进行操作"");
            }
        }
        function deletes(){
            var ids=backend.getCheckIds();
            if(ids.length<1){
                backend.Tip(""至少选择一条进行操作"");
            }
            else{
                backend.confirm(""您确定要执行此操作吗？"",null,function(index){
                    backend.post(""");

            
            #line 109 "..\..\Areas\Backend\Views\Havior\Select.cshtml"
                             Write(Url.Action("Delete", "Havior", new { }));

            
            #line default
            #line hidden
WriteLiteral("\",{ids:ids.toString()},function(data){\r\n                        $(\"#page\").pagina" +
"tion(\'remote\');\r\n                    });\r\n                });\r\n            }\r\n  " +
"      }\r\n    </script>\r\n    <script");

WriteLiteral(" type=\"text/html\"");

WriteLiteral(" id=\"tpl\"");

WriteLiteral(@">
        <% for(var i=0;i < data.length;i++){ %>
        <tr>
            <td class=""monk-td-radio"">
                <span class=""monk-iconfont icon-backend-checkbox list-radio"" data-id=""<%=data[i].HaviorID%>""></span>
            </td>
            <td>
                <%=data[i].Name %>
            </td>
            <td>
                <%=backend.setNull(data[i].Url,""无"") %>
            </td>
            <td>
                <%=backend.setNull(data[i].Layout,""无"") %>
            </td>
            <td>
                <%=data[i].ModuleName %>
            </td>
            <td class=""monk-table-status"">
                <label <%=data[i].HttpMethod==""POST""?"" class='tipcolor' "":"""" %>><%=data[i].HttpMethod %></label>
            </td>
            <td class=""monk-table-status"">
                <%=backend.setStatus(data[i].Route) %>
            </td>
            <td class=""monk-table-status"">
                <%=backend.setStatus(data[i].Index) %>
            </td>
            <td class=""monk-table-status"">
                <%=backend.setStatus(data[i].Enable) %>
            </td>
            <td class=""monk-table-status"">
                <%=backend.setStatus(data[i].Default) %>
            </td>
        </tr>
        <% } %>
    </script>
    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(function () {\r\n            var render= monk.tppl(document.getElement" +
"ById(\"tpl\").innerHTML);\r\n            backend.pagination(\"");

            
            #line 155 "..\..\Areas\Backend\Views\Havior\Select.cshtml"
                           Write(Url.Action("List","Havior"));

            
            #line default
            #line hidden
WriteLiteral("\",");

            
            #line 155 "..\..\Areas\Backend\Views\Havior\Select.cshtml"
                                                         Write(ViewBag.SysSetInfo.PageSize);

            
            #line default
            #line hidden
WriteLiteral(",{},function(data){\r\n                var html=  render(data);\r\n                $(" +
"\".monk-table table tbody\").html(html);\r\n            });\r\n        });\r\n    </scri" +
"pt>\r\n");

});

        }
    }
}
#pragma warning restore 1591