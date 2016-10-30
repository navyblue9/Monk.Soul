using System;

namespace Monk.Areas.Backend.ViewModels
{
    public class SysSetVM
    {
        public Guid SetID { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Support { get; set; }
        public string Copyright { get; set; }
        public string Site { get; set; }
        public int PageSize { get; set; }
        public int ImageMaxSize { get; set; }
        public int VideoMaxSize { get; set; }
        public int AttachMaxSize { get; set; }
        public int SerialNo { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Boolean Default { get; set; }
        public Boolean Del { get; set; }
        public Boolean Destroy { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid LogMemberID { get; set; }
    }
}
