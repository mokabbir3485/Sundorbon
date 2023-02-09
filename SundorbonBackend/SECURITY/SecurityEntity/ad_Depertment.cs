using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ad_Depertment
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public string DepartmentName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string BranchName { get; set; } = null;
    }
}
