using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class Content
    {
        
        /// <summary>
        /// Desc:ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid ContentID {get;set;}

        /// <summary>
        /// Desc:标题 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Title {get;set;}

        /// <summary>
        /// Desc:Html内容 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string HtmlText {get;set;}

        /// <summary>
        /// Desc:Markdown内容 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string MarkdownText {get;set;}

        /// <summary>
        /// Desc:分类ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid ClassifyID {get;set;}

        /// <summary>
        /// Desc:作者 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Author {get;set;}

        /// <summary>
        /// Desc:来源 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Source {get;set;}

        /// <summary>
        /// Desc:发布时间 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public DateTime PushTime {get;set;}

        /// <summary>
        /// Desc:IP地址 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string IPAddress {get;set;}

        /// <summary>
        /// Desc:IP详情 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string IPDetail {get;set;}

        /// <summary>
        /// Desc:发布人 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid MemberID {get;set;}

        /// <summary>
        /// Desc:审核状态 
        /// Default:((0)) 
        /// Nullable:False 
        /// </summary>
        public Boolean Pass {get;set;}

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
