using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ad_ItemReport
    {
        public string GroupName { get; set; }
        public string ProductName { get; set; }
        public string ItemCode { get; set; }
        public string ModelName { get; set; }
        public string UnitDescription { get; set; }
        public bool HasExpiry { get; set; }
        public bool IsActive { get; set; }
    }
}
