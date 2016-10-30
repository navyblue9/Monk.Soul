using System;

namespace Monk.Areas.Backend.ViewModels
{
    public class LoginLogVM
    {
        public Guid LogID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? OffTime { get; set; }
        public Boolean Sucessed { get; set; }
        public Guid? MemberID { get; set; }
        public string IPAddress { get; set; }
        public string IPDetail { get; set; }
        public string HttpMethod { get; set; }
        public Boolean AjaxRequest { get; set; }
        public Boolean MobileDevice { get; set; }
        public string Platform { get; set; }
        public string Browser { get; set; }
        public int SerialNo { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Boolean Default { get; set; }
        public Boolean Del { get; set; }
        public Boolean Destroy { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid LogMemberID { get; set; }
    }
}
