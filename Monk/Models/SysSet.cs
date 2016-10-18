using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class SysSet
    {
        
        /// <summary>
        /// Desc:ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid SetID {get;set;}

        /// <summary>
        /// Desc:LOGO 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Logo {get;set;}

        /// <summary>
        /// Desc:名称 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// Desc:版本 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string Version {get;set;}

        /// <summary>
        /// Desc:关键字 
        /// Default:('Monk.Soul,百签软件,百小僧,baisoft,baisoft.org') 
        /// Nullable:True 
        /// </summary>
        public string Keywords {get;set;}

        /// <summary>
        /// Desc:描述 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Description {get;set;}

        /// <summary>
        /// Desc:技术支持 
        /// Default:('百签软件（中山）有限公司') 
        /// Nullable:False 
        /// </summary>
        public string Support {get;set;}

        /// <summary>
        /// Desc:版权所有 
        /// Default:('Copyright ?  2016 百签软件（中山）有限公司. All rights reserved.') 
        /// Nullable:False 
        /// </summary>
        public string CopyRight {get;set;}

        /// <summary>
        /// Desc:网址 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Site {get;set;}

        /// <summary>
        /// Desc:页容量 
        /// Default:((15)) 
        /// Nullable:False 
        /// </summary>
        public int PageSize {get;set;}

        /// <summary>
        /// Desc:图片最大上传大小 
        /// Default:((2.0)) 
        /// Nullable:False 
        /// </summary>
        public Decimal ImageMaxSize {get;set;}

        /// <summary>
        /// Desc:视频最大上传大小 
        /// Default:((5.0)) 
        /// Nullable:False 
        /// </summary>
        public Decimal VideoMaxSize {get;set;}

        /// <summary>
        /// Desc:附件最大上传大小 
        /// Default:((10.0)) 
        /// Nullable:False 
        /// </summary>
        public Decimal AttachMaxSize {get;set;}

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
