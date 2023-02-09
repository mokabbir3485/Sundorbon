using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_StoreIssueDetails
    {
        public Int32 Id { get; set; }
        public string IssueNumber { get; set; }
        public Int32 RackId { get; set; }
        public Int32 ItemId { get; set; }
        public Decimal IssuedQty { get; set; }
        public Decimal IssuedPrice { get; set; }
        public string Remarks { get; set; }

        public string ProductName { get; set; }
        public Decimal RequestedQty{ get; set; }
    }
}
