using System;
using System.Linq;
using System.Text;

namespace Monk.ViewModels
{
    public class HaviorVM
    {

        /// <summary>
        /// Desc:ID
        /// Default:-
        /// Nullable:False
        /// </summary>
        public Guid HaviorID {get;set;}

        /// <summary>
        /// Desc:名称
        /// Default:-
        /// Nullable:False
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// Desc:关键字
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string Remark {get;set;}

        /// <summary>
        /// Desc:路由
        /// Default:((1))
        /// Nullable:False
        /// </summary>
        public Boolean Route {get;set;}

        /// <summary>
        /// Desc:请求地址
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string Url {get;set;}

        /// <summary>
        /// Desc:区域
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string Area {get;set;}

        /// <summary>
        /// Desc:控制器
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string Controller {get;set;}

        /// <summary>
        /// Desc:功能
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string Action {get;set;}

        /// <summary>
        /// Desc:路由参数
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string Parameter {get;set;}

        /// <summary>
        /// Desc:HTTP方式
        /// Default:('GET')
        /// Nullable:False
        /// </summary>
        public string HttpMethod {get;set;}

        /// <summary>
        /// Desc:页头代码
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string HeadCode {get;set;}

        /// <summary>
        /// Desc:页脚代码
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string FootCode {get;set;}

        /// <summary>
        /// Desc:布局地址
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string Layout {get;set;}

        /// <summary>
        /// Desc:模块ID
        /// Default:-
        /// Nullable:False
        /// </summary>
        public Guid ModuleID {get;set;}

        /// <summary>
        /// Desc:首页
        /// Default:((0))
        /// Nullable:False
        /// </summary>
        public Boolean Index {get;set;}

        /// <summary>
        /// Desc:启用
        /// Default:((1))
        /// Nullable:False
        /// </summary>
        public Boolean Enable {get;set;}

        /// <summary>
        /// Desc:流水号
        /// Default:-
        /// Nullable:False
        /// </summary>
        public int SerialNo {get;set;}

        /// <summary>
        /// Desc:更新时间
        /// Default:-
        /// Nullable:True
        /// </summary>
        public DateTime? UpdateTime {get;set;}

        /// <summary>
        /// Desc:默认
        /// Default:((0))
        /// Nullable:False
        /// </summary>
        public Boolean Default {get;set;}

        /// <summary>
        /// Desc:软删除
        /// Default:((0))
        /// Nullable:False
        /// </summary>
        public Boolean Del {get;set;}

        /// <summary>
        /// Desc:硬删除
        /// Default:((0))
        /// Nullable:False
        /// </summary>
        public Boolean Destroy {get;set;}

        /// <summary>
        /// Desc:创建时间
        /// Default:(getdate())
        /// Nullable:False
        /// </summary>
        public DateTime CreateTime {get;set;}

        /// <summary>
        /// Desc:记录会员
        /// Default:-
        /// Nullable:False
        /// </summary>
        public Guid LogMemberID {get;set;}

    }
}
