using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class Member
    {
        
				///<summary>
                /// 描述：ID
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Guid MemberID {get;set;}

				///<summary>
                /// 描述：账号
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Account {get;set;}

				///<summary>
                /// 描述：密码
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Password {get;set;}

				///<summary>
                /// 描述：邮箱
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Email {get;set;}

				///<summary>
                /// 描述：手机
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Phone {get;set;}

				///<summary>
                /// 描述：照片
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Photo {get;set;}

				///<summary>
                /// 描述：描述
                /// 默认值：('亲，你还没介绍自己哦~')
                /// 可空：True
				/// </summary>
		         public string Remark {get;set;}

				///<summary>
                /// 描述：会员组ID
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Guid GroupID {get;set;}

				///<summary>
                /// 描述：启用
                /// 默认值：((1))
                /// 可空：False
				/// </summary>
		         public Boolean Enable {get;set;}

				///<summary>
                /// 描述：审核
                /// 默认值：((1))
                /// 可空：False
				/// </summary>
		         public Boolean Pass {get;set;}

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
