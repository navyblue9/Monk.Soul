using System;

namespace Monk.Areas.Backend.ViewModels
{
    public class V_ModuleVM
    {
        public Guid ModuleID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public int Sort { get; set; }
        public string TagAttr { get; set; }
        public Guid ParentID { get; set; }
        public string Iconfont { get; set; }
        public Boolean Enable { get; set; }
        public int SerialNo { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Boolean Default { get; set; }
        public Boolean Del { get; set; }
        public Boolean Destroy { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid LogMemberID { get; set; }
        public string ParentName { get; set; }
        public Guid? HaviorID { get; set; }
        public string HaviorName { get; set; }
        public string HttpMethod { get; set; }
        public string Url { get; set; }
    }
}
