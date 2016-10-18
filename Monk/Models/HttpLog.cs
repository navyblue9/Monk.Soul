using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class HttpLog
    {
        
				///<summary>
                /// 描述：ID
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Guid LogID {get;set;}

				///<summary>
                /// 描述：来源地址
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Referrer {get;set;}

				///<summary>
                /// 描述：请求地址
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Url {get;set;}

				///<summary>
                /// 描述：传输数据
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Data {get;set;}

				///<summary>
                /// 描述：会员ID
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public Guid? MemberID {get;set;}

				///<summary>
                /// 描述：IP地址
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string IPAddress {get;set;}

				///<summary>
                /// 描述：IP详情
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string IPDetail {get;set;}

				///<summary>
                /// 描述：HTTP方式
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string HttpMethod {get;set;}

				///<summary>
                /// 描述：异步请求
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Boolean AjaxRequest {get;set;}

				///<summary>
                /// 描述：移动设备
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Boolean MobileDevice {get;set;}

				///<summary>
                /// 描述：操作系统
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Platform {get;set;}

				///<summary>
                /// 描述：浏览器
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Browser {get;set;}

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
