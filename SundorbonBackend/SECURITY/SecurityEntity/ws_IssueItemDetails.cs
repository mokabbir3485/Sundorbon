using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ws_IssueItemDetails
    {
        public int Id { get; set; }
        public string IssueNumber { get; set; }
        public int RackId { get; set; }
        public int StoreId { get; set; }
        public decimal IssuedQty { get; set; }
        public decimal IssuedPrice { get; set; }
        public bool IsVoid { get; set; }
        public string Remarks { get; set; }
        public string RackDescription { get; set; }
        public string StoreName { get; set; }
    }
}
