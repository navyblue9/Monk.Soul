using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class OperateDetail
    {
        
        /// <summary>
        /// Desc:ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid DetailID {get;set;}

        /// <summary>
        /// Desc:操作日志ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid LogID {get;set;}

        /// <summary>
        /// Desc:字段名称 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string ColumnName {get;set;}

        /// <summary>
        /// Desc:字段描述 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string ColumnRemark {get;set;}

        /// <summary>
        /// Desc:旧值 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string OldValue {get;set;}

        /// <summary>
        /// Desc:新值 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string NewValue {get;set;}

        /// <summary>
        /// Desc:会员ID 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Guid? MemberID {get;set;}

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
