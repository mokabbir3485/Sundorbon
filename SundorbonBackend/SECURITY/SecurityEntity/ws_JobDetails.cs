using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ws_JobDetails
    {
        public Int32 Id { get; set; }
        public string JobNumber { get; set; }
        public string WorkDetails { get; set; }
        public bool IsVoid { get; set; }
    }
}
