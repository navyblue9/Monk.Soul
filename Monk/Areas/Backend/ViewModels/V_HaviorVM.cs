using System;

namespace Monk.Areas.Backend.ViewModels
{
    public class V_HaviorVM
    {
        public Guid HaviorID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public Boolean Route { get; set; }
        public string Url { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Parameter { get; set; }
        public string HttpMethod { get; set; }
        public string HeadCode { get; set; }
        public string FootCode { get; set; }
        public string Layout { get; set; }
        public Guid ModuleID { get; set; }
        public Boolean Index { get; set; }
        public Boolean Enable { get; set; }
        public int SerialNo { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Boolean Default { get; set; }
        public Boolean Del { get; set; }
        public Boolean Destroy { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid LogMemberID { get; set; }
        public string ModuleName { get; set; }
        public int? ModuleSort { get; set; }
        public string Crumbs { get; set; }
        public string Buttons { get; set; }
    }
}
