using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class State
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
                /// 可空：False
				/// </summary>
		         public int JobId {get;set;}

				///<summary>
                /// 描述：-
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Name {get;set;}

				///<summary>
                /// 描述：-
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Reason {get;set;}

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
		         public string Data {get;set;}

    }
}
