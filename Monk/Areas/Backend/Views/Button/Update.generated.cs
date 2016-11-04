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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Backend/Views/Button/Update.cshtml")]
    public partial class _Areas_Backend_Views_Button_Update_cshtml : System.Web.Mvc.WebViewPage<V_ButtonVM>
    {
        public _Areas_Backend_Views_Button_Update_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Backend\Views\Button\Update.cshtml"
  
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

            
            #line 11 "..\..\Areas\Backend\Views\Button\Update.cshtml"
Write(Html.Raw(ViewBag.HaviorInfo.HeadCode));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 12 "..\..\Areas\Backend\Views\Button\Update.cshtml"
Write(Styles.Render("~/Assets/Backend/Editor.MD/Style"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

DefineSection("crumbs", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 16 "..\..\Areas\Backend\Views\Button\Update.cshtml"
Write(Html.Raw(ViewBag.HaviorInfo.Crumbs));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

DefineSection("beginForm", () => {

            
            #line 19 "..\..\Areas\Backend\Views\Button\Update.cshtml"
                      Html.BeginForm("Update", "Button", FormMethod.Post, new { @class = "monk-form" });
            
            #line default
            #line hidden
});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Havior\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">所属行为</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap\"");

WriteLiteral(">\r\n        <input");

WriteLiteral(" datatype=\"*\"");

WriteLiteral(" errormsg=\"请选择所属行为\"");

WriteLiteral(" id=\"HaviorID\"");

WriteLiteral(" name=\"HaviorID\"");

WriteLiteral(" nullmsg=\"请选择所属行为\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 846), Tuple.Create("\"", 869)
            
            #line 24 "..\..\Areas\Backend\Views\Button\Update.cshtml"
                                     , Tuple.Create(Tuple.Create("", 854), Tuple.Create<System.Object, System.Int32>(Model.HaviorID
            
            #line default
            #line hidden
, 854), false)
);

WriteLiteral(" />\r\n        <input");

WriteLiteral(" class=\"monk-form-input normal\"");

WriteLiteral(" id=\"Havior\"");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 944), Tuple.Create("\"", 969)
            
            #line 25 "..\..\Areas\Backend\Views\Button\Update.cshtml"
, Tuple.Create(Tuple.Create("", 952), Tuple.Create<System.Object, System.Int32>(Model.HaviorName
            
            #line default
            #line hidden
, 952), false)
);

WriteLiteral(" placeholder=\"请输入或选择所属行为\"");

WriteLiteral(" />\r\n        <span");

WriteLiteral(" class=\"monk-iconfont icon-monk-required\"");

WriteLiteral("></span>\r\n        <span");

WriteLiteral(" class=\"monk-iconfont monk-select-arrow icon-backend-search-list border-left\"");

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">请输入或选择所属行为</div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Name\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">按钮名称</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-right icon-monk-input\"");

WriteLiteral("></span>\r\n");

WriteLiteral("        ");

            
            #line 36 "..\..\Areas\Backend\Views\Button\Update.cshtml"
   Write(Html.TextBoxFor(u => u.Name,
        new
        {
            @class = "monk-form-input normal",
            placeholder = "按钮名称",
            datatype = "*1-16",
            errormsg = "按钮名称由1-16位英文字母、数字或符号组成",
            nullmsg = "请输入按钮名称"
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <span");

WriteLiteral(" class=\"monk-iconfont icon-monk-required\"");

WriteLiteral("></span>\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-left icon-monk-dacha monk-clear-input\"");

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">通常按钮名称不宜过长，2-4个字最为恰当</div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Remark\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">按钮描述</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-right icon-monk-input textarea-icon\"");

WriteLiteral("></span>\r\n");

WriteLiteral("        ");

            
            #line 55 "..\..\Areas\Backend\Views\Button\Update.cshtml"
   Write(Html.TextAreaFor(u => u.Remark,
        new
        {
            @class = "monk-form-textarea normal",
            placeholder = "按钮描述",
            datatype = "*1-100",
            ignore = "ignore",
            errormsg = "按钮描述由1-100位英文字母、数字或符号组成",
            nullmsg = "请输入按钮描述"
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-left icon-monk-dacha monk-clear-input textarea-icon\"" +
"");

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">简单一句话，描述一下该按钮的作用吧。</div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Sort\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">排序数字</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-right icon-monk-input\"");

WriteLiteral("></span>\r\n");

WriteLiteral("        ");

            
            #line 74 "..\..\Areas\Backend\Views\Button\Update.cshtml"
   Write(Html.TextBoxFor(u => u.Sort,
        new
        {
            @class = "monk-form-input min",
            placeholder = "排序数字",
            datatype = "n",
            errormsg = "排序数字必须是正整数",
            nullmsg = "请输入排序数字"
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <span");

WriteLiteral(" class=\"monk-iconfont icon-monk-required\"");

WriteLiteral("></span>\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-left icon-monk-dacha monk-clear-input\"");

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">数字越小，越排前面</div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Event\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">绑定事件</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap monk-form-select-wrap\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-right icon-monk-input\"");

WriteLiteral("></span>\r\n        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"monk-form-input min\"");

WriteLiteral(" placeholder=\"请输入或选择...\"");

WriteLiteral(" />\r\n        <span");

WriteLiteral(" class=\"monk-iconfont icon-monk-required\"");

WriteLiteral("></span>\r\n        <span");

WriteLiteral(" class=\"monk-iconfont monk-select-arrow icon-monk-arrowdown border-left\"");

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-select monk-none\"");

WriteLiteral(">\r\n        <select");

WriteLiteral(" class=\"monk-select\"");

WriteLiteral(" name=\"Event\"");

WriteLiteral(" datatype=\"*\"");

WriteLiteral(" nullmsg=\"请选择绑定事件\"");

WriteLiteral(" errormsg=\"请选择绑定事件\"");

WriteLiteral(" data-value=\"");

            
            #line 98 "..\..\Areas\Backend\Views\Button\Update.cshtml"
                                                                                                          Write(Model.Event);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n            <option");

WriteLiteral(" value=\"\"");

WriteLiteral(">请输入或选择...</option>\r\n            <option");

WriteLiteral(" value=\"onclick\"");

WriteLiteral(">单击</option>\r\n            <option");

WriteLiteral(" value=\"ondblclick\"");

WriteLiteral(">双击</option>\r\n        </select>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">为该按钮绑定触发事件类型，通常选择 单击事件（onclick）</div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Invoke\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">调用方法</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-right icon-monk-input\"");

WriteLiteral("></span>\r\n");

WriteLiteral("        ");

            
            #line 111 "..\..\Areas\Backend\Views\Button\Update.cshtml"
   Write(Html.TextBoxFor(u => u.Invoke,
        new
        {
            @class = "monk-form-input normal",
            placeholder = "调用方法",
            datatype = "*1-100",
            ignore = "ignore",
            errormsg = "调用方法由1-100位英文字母、数字或符号组成",
            nullmsg = "请输入调用方法"
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-left icon-monk-dacha monk-clear-input\"");

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">通常格式为：insert(this); ，为了避免标签单双引号冲突问题，规定全部字符串用 <label");

WriteLiteral(" class=\"tipcolor\"");

WriteLiteral(">单引号</label></div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Handle\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">方法定义</label>\r\n    <div");

WriteLiteral(" class=\"monk-editor-code\"");

WriteLiteral(" id=\"handle-code\"");

WriteLiteral("><textarea");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">");

            
            #line 128 "..\..\Areas\Backend\Views\Button\Update.cshtml"
                                                                              Write(Model.Handle);

            
            #line default
            #line hidden
WriteLiteral("</textarea></div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">这里写完整的方法定义代码，如：function insert(e){ // 你的代码 };，<label");

WriteLiteral(" class=\"tipcolor\"");

WriteLiteral(">按F11可以全屏，ESC可以退出</label></div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"TagAttr\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">标签属性</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-right icon-monk-input textarea-icon\"");

WriteLiteral("></span>\r\n");

WriteLiteral("        ");

            
            #line 136 "..\..\Areas\Backend\Views\Button\Update.cshtml"
   Write(Html.TextAreaFor(u => u.TagAttr,
        new
        {
            @class = "monk-form-textarea normal",
            placeholder = "标签属性",
            datatype = "*1-100",
            ignore = "ignore",
            errormsg = "标签属性由1-100位英文字母、数字或符号组成",
            nullmsg = "请输入标签属性"
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-left icon-monk-dacha monk-clear-input textarea-icon\"" +
"");

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">可以为按钮标签添加HTML属性，如：style=\"color:#000;\" data-name=\"xxx\"</div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Iconfont\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">字体图标</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-wrap\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-right icon-monk-input\"");

WriteLiteral("></span>\r\n");

WriteLiteral("        ");

            
            #line 154 "..\..\Areas\Backend\Views\Button\Update.cshtml"
   Write(Html.TextBoxFor(u => u.Iconfont,
        new
        {
            @class = "monk-form-input normal",
            placeholder = "字体图标",
            datatype = "*1-50",
            ignore = "ignore",
            errormsg = "字体图标由1-50位英文字母、数字或符号组成",
            nullmsg = "请输入字体图标"
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <span");

WriteLiteral(" class=\"monk-iconfont border-left icon-monk-dacha monk-clear-input\"");

WriteLiteral("></span>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">目前只支持阿里图标，格式为：icon-图标class，默认为文件字体图标</div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"monk-form-item\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Enable\"");

WriteLiteral(" class=\"monk-form-label\"");

WriteLiteral(">开放状态</label>\r\n    <div");

WriteLiteral(" class=\"monk-form-switch-list\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 172 "..\..\Areas\Backend\Views\Button\Update.cshtml"
   Write(Html.CheckBoxFor(u => u.Enable,
       new
       {
           @class = "monk-switch",
           text = "开放"
       }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"monk-form-tip\"");

WriteLiteral(">设置该按钮是否开放</div>\r\n</div>\r\n\r\n");

DefineSection("operate", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 183 "..\..\Areas\Backend\Views\Button\Update.cshtml"
Write(Html.HiddenFor(u => u.ButtonID));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 184 "..\..\Areas\Backend\Views\Button\Update.cshtml"
Write(Html.Raw(ViewBag.HaviorInfo.FormButtons));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

DefineSection("endForm", () => {

            
            #line 187 "..\..\Areas\Backend\Views\Button\Update.cshtml"
                    Html.EndForm();
            
            #line default
            #line hidden
});

WriteLiteral("\r\n");

DefineSection("foot", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 190 "..\..\Areas\Backend\Views\Button\Update.cshtml"
Write(Html.Raw(ViewBag.HaviorInfo.FootCode));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 191 "..\..\Areas\Backend\Views\Button\Update.cshtml"
Write(Scripts.Render("~/Assets/Backend/Editor.MD/Script", "~/Assets/Backend/AutoComplete/Script"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(function () {\r\n            backend.autoComplete(\'#Havior\', \'");

            
            #line 194 "..\..\Areas\Backend\Views\Button\Update.cshtml"
                                        Write(Url.Action("Haviors", "Button"));

            
            #line default
            #line hidden
WriteLiteral(@"', function (suggestion) {
                $(""#HaviorID"").val(suggestion.data);
            });
            var handlecode = backend.codeEditor(""handle-code"", ""Handle"", ""javascript"");
            backend.validform(function (data) {
                window.location.href = """);

            
            #line 199 "..\..\Areas\Backend\Views\Button\Update.cshtml"
                                   Write(Url.Action("Detail","Button",new { id=Model.ButtonID}));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            });\r\n        });\r\n    </script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
