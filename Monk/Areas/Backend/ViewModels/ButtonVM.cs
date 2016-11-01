using System;

namespace Monk.Areas.Backend.ViewModels
{
    public class ButtonVM
    {
        public Guid ButtonID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public int Sort { get; set; }
        public string Event { get; set; }
        public string Invoke { get; set; }
        public string Handle { get; set; }
        public string TagAttr { get; set; }
        public string Iconfont { get; set; }
        public Guid HaviorID { get; set; }
        public Boolean Enable { get; set; }
        public int SerialNo { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Boolean Default { get; set; }
        public Boolean Del { get; set; }
        public Boolean Destroy { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid LogMemberID { get; set; }
    }
}
