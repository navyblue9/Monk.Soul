using System;
using System.Linq;
using System.Text;

namespace Monk.Areas.Backend.ViewModels
{
    public class GroupVM
    {
        public Guid GroupID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public Guid ParentID { get; set; }
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
