using System;

namespace Monk.Areas.Backend.ViewModels
{
    public class MenuVM
    {
        public Guid ModuleID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public int Sort { get; set; }
        public string TagAttr { get; set; }
        public Guid ParentID { get; set; }
        public string Iconfont { get; set; }
        public string Url { get; set; }
    }
}