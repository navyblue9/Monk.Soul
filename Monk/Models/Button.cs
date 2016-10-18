using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class Button
    {
        
        /// <summary>
        /// Desc:ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid ButtonID {get;set;}

        /// <summary>
        /// Desc:名称 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// Desc:描述 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Remark {get;set;}

        /// <summary>
        /// Desc:排序 
        /// Default:((0)) 
        /// Nullable:False 
        /// </summary>
        public int Sort {get;set;}

        /// <summary>
        /// Desc:事件 
        /// Default:('onclick') 
        /// Nullable:False 
        /// </summary>
        public string Event {get;set;}

        /// <summary>
        /// Desc:调用 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Invoke {get;set;}

        /// <summary>
        /// Desc:处理 
        /// Default:('') 
        /// Nullable:False 
        /// </summary>
        public string Handle {get;set;}

        /// <summary>
        /// Desc:标签属性 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string TagAttr {get;set;}

        /// <summary>
        /// Desc:字体图标 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Iconfont {get;set;}

        /// <summary>
        /// Desc:行为ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid HaviorID {get;set;}

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
