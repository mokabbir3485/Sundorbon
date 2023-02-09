using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class wsOutDoorJobDetails
    {
        public Int32 Id { get; set; }
        public string OJobNumber { get; set; }
        public string OutdoorWorkDetails { get; set; }
        public bool IsVoid { get; set; }
    }
}
