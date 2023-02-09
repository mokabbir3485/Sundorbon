using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
     public class ad_Counter
    {
        public Int32 Id { get; set; }
        public string CounterName { get; set; }
        public Int32 DepartmentId { get; set; }
        public string IPAddress { get; set; }
        public string ShortCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
