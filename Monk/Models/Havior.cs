using System;
using System.Linq;
using System.Text;

namespace Monk.Models
{
    public class Havior
    {
        
				///<summary>
                /// 描述：ID
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Guid HaviorID {get;set;}

				///<summary>
                /// 描述：名称
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Name {get;set;}

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
                /// 描述：路由
                /// 默认值：((1))
                /// 可空：False
				/// </summary>
		         public Boolean Route {get;set;}

				///<summary>
                /// 描述：请求地址
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Url {get;set;}

				///<summary>
                /// 描述：区域
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Area {get;set;}

				///<summary>
                /// 描述：控制器
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Controller {get;set;}

				///<summary>
                /// 描述：功能
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Action {get;set;}

				///<summary>
                /// 描述：标签属性
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string TagAttr {get;set;}

				///<summary>
                /// 描述：字体图标
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public string Iconfont {get;set;}

				///<summary>
                /// 描述：HTTP方式
                /// 默认值：('GET')
                /// 可空：False
				/// </summary>
		         public string HttpMethod {get;set;}

				///<summary>
                /// 描述：页头代码
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string HeadCode {get;set;}

				///<summary>
                /// 描述：页脚代码
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string FootCode {get;set;}

				///<summary>
                /// 描述：布局地址
                /// 默认值：-
                /// 可空：True
				/// </summary>
		         public string Layout {get;set;}

				///<summary>
                /// 描述：模块ID
                /// 默认值：-
                /// 可空：False
				/// </summary>
		         public Guid ModuleID {get;set;}

				///<summary>
                /// 描述：首页
                /// 默认值：((0))
                /// 可空：False
				/// </summary>
		         public Boolean Index {get;set;}

				///<summary>
                /// 描述：启用
                /// 默认值：((1))
                /// 可空：False
				/// </summary>
		         public Boolean Enable {get;set;}

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
