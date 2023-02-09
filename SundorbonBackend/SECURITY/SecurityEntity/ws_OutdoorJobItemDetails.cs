using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ws_OutdoorJobItemDetails
    {
        public Int32 Id { get; set; }
        public string OJobNumber { get; set; }
        public Int32 ItemId { get; set; }
        public decimal ItemRequiredFromOutdoorQty { get; set; }
        public decimal OItemReusableQty { get; set; }
        public decimal ItemDamagedQty { get; set; }
        public bool IsVoid { get; set; }
        public string Remarks { get; set; }
        public string Combination { get; set; }
    }
}
