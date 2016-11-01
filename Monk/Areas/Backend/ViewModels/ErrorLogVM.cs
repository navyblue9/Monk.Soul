using System;

namespace Monk.Areas.Backend.ViewModels
{
    public class ErrorLogVM
    {
        public Guid LogID { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string TargetSite { get; set; }
        public string StackTrace { get; set; }
        public string HResult { get; set; }
        public string HelpLink { get; set; }
        public DateTime LogTime { get; set; }
        public string Account { get; set; }
        public string ErrorUrl { get; set; }
        public Boolean View { get; set; }
        public int SerialNo { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Boolean Default { get; set; }
        public Boolean Del { get; set; }
        public Boolean Destroy { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid LogMemberID { get; set; }
    }
}
