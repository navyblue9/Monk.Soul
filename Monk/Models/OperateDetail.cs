using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class OperateDetail
    {
        
				///<summary>
                /// 描述：ID
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Guid DetailID {get;set;}

				///<summary>
                /// 描述：操作日志ID
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Guid LogID {get;set;}

				///<summary>
                /// 描述：字段名称
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string ColumnName {get;set;}

				///<summary>
                /// 描述：字段描述
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string ColumnRemark {get;set;}

				///<summary>
                /// 描述：旧值
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string OldValue {get;set;}

				///<summary>
                /// 描述：新值
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string NewValue {get;set;}

				///<summary>
                /// 描述：会员ID
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public Guid? MemberID {get;set;}

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
