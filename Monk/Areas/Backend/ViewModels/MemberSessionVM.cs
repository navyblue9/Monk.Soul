using System;

namespace Monk.Areas.Backend.ViewModels
{
    [Serializable]
    public class MemberSessionVM
    {
        public Guid MemberID { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string Remark { get; set; }
        public Guid GroupID { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid LogID { get; set; }
    }
}