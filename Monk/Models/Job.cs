using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class Job
    {
        
				///<summary>
                /// 描述：-
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public int Id {get;set;}

				///<summary>
                /// 描述：-
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public int? StateId {get;set;}

				///<summary>
                /// 描述：-
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string StateName {get;set;}

				///<summary>
                /// 描述：-
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string InvocationData {get;set;}

				///<summary>
                /// 描述：-
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Arguments {get;set;}

				///<summary>
                /// 描述：-
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public DateTime CreatedAt {get;set;}

				///<summary>
                /// 描述：-
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public DateTime? ExpireAt {get;set;}

    }
}
