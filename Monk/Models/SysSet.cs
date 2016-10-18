using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class SysSet
    {
        
				///<summary>
                /// 描述：ID
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Guid SetID {get;set;}

				///<summary>
                /// 描述：LOGO
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Logo {get;set;}

				///<summary>
                /// 描述：名称
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Name {get;set;}

				///<summary>
                /// 描述：版本
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Version {get;set;}

				///<summary>
                /// 描述：关键字
                /// 默认值：('Monk.Soul,百签软件,百小僧,baisoft,baisoft.org')
                /// 可空：True
				/// </summary>
		         public string Keywords {get;set;}

				///<summary>
                /// 描述：描述
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Description {get;set;}

				///<summary>
                /// 描述：技术支持
                /// 默认值：('百签软件（中山）有限公司')
                /// 可空：False
				/// </summary>
		         public string Support {get;set;}

				///<summary>
                /// 描述：版权所有
                /// 默认值：('Copyright ?  2016 百签软件（中山）有限公司. All rights reserved.')
                /// 可空：False
				/// </summary>
		         public string CopyRight {get;set;}

				///<summary>
                /// 描述：网址
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Site {get;set;}

				///<summary>
                /// 描述：页容量
                /// 默认值：((15))
                /// 可空：False
				/// </summary>
		         public int PageSize {get;set;}

				///<summary>
                /// 描述：图片最大上传大小
                /// 默认值：((2.0))
                /// 可空：False
				/// </summary>
		         public Decimal ImageMaxSize {get;set;}

				///<summary>
                /// 描述：视频最大上传大小
                /// 默认值：((5.0))
                /// 可空：False
				/// </summary>
		         public Decimal VideoMaxSize {get;set;}

				///<summary>
                /// 描述：附件最大上传大小
                /// 默认值：((10.0))
                /// 可空：False
				/// </summary>
		         public Decimal AttachMaxSize {get;set;}

				///<summary>
                /// 描述：流水号
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public int SerialNo {get;set;}

				///<summary>
                /// 描述：更新时间
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public DateTime? UpdateTime {get;set;}

				///<summary>
                /// 描述：默认
                /// 默认值：((0))
                /// 可空：False
				/// </summary>
		         public Boolean Default {get;set;}

				///<summary>
                /// 描述：软删除
                /// 默认值：((0))
                /// 可空：False
				/// </summary>
		         public Boolean Del {get;set;}

				///<summary>
                /// 描述：硬删除
                /// 默认值：((0))
                /// 可空：False
				/// </summary>
		         public Boolean Destroy {get;set;}

				///<summary>
                /// 描述：创建时间
                /// 默认值：(getdate())
                /// 可空：False
				/// </summary>
		         public DateTime CreateTime {get;set;}

				///<summary>
                /// 描述：记录会员
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Guid LogMemberID {get;set;}

    }
}
