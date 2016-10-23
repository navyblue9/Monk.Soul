using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monk.Areas.Backend.ViewModels
{
    [Serializable]
    public class SessionMember
    {
        public Guid MemberID { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string Remark { get; set; }
        public Guid GroupID { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid LogID { get; set; }
    }
}