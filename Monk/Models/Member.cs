using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class Member
    {
        
        /// <summary>
        /// Desc:ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid MemberID {get;set;}

        /// <summary>
        /// Desc:账号 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Account {get;set;}

        /// <summary>
        /// Desc:密码 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Password {get;set;}

        /// <summary>
        /// Desc:邮箱 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Email {get;set;}

        /// <summary>
        /// Desc:手机 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Phone {get;set;}

        /// <summary>
        /// Desc:照片 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Photo {get;set;}

        /// <summary>
        /// Desc:描述 
        /// Default:('亲，你还没介绍自己哦~') 
        /// Nullable:True 
        /// </summary>
        public string Remark {get;set;}

        /// <summary>
        /// Desc:会员组ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid GroupID {get;set;}

        /// <summary>
        /// Desc:启用 
        /// Default:((1)) 
        /// Nullable:False 
        /// </summary>
        public Boolean Enable {get;set;}

        /// <summary>
        /// Desc:审核 
        /// Default:((1)) 
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
