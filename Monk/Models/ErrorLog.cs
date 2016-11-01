using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class ErrorLog
    {
        
        /// <summary>
        /// Desc:ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid LogID {get;set;}

        /// <summary>
        /// Desc:异常消息 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Message {get;set;}

        /// <summary>
        /// Desc:应用程序 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Source {get;set;}

        /// <summary>
        /// Desc:引起异常的方法 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string TargetSite {get;set;}

        /// <summary>
        /// Desc:异常堆栈信息 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string StackTrace {get;set;}

        /// <summary>
        /// Desc:异常编码数字 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string HResult {get;set;}

        /// <summary>
        /// Desc:异常帮助文档 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string HelpLink {get;set;}

        /// <summary>
        /// Desc:记录时间 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public DateTime LogTime {get;set;}

        /// <summary>
        /// Desc:账号 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Account {get;set;}

        /// <summary>
        /// Desc:出错地址 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string ErrorUrl {get;set;}

        /// <summary>
        /// Desc:查看状态 
        /// Default:((0)) 
        /// Nullable:False 
        /// </summary>
        public Boolean View {get;set;}

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
