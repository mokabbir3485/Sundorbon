using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ws_StoreItemReceiveDetails
    {
        public Int32 Id { get; set; }
        public string StoreReceiveNumber { get; set; }
        public Int32 StoreId { get; set; }
        public Int32 RackId { get; set; }
        public Int32 ItemId { get; set; }
        public Decimal ReceiveQty { get; set; }
        public Decimal ReceivedPrice { get; set; }
        public bool IsVoid { get; set; }
        public string Remarks { get; set; }
        public string TransactiontionType { get; set; }
        public string StoreName { get; set; }
        public string RackDescription { get; set; }
        public string ProductName { get; set; }
    }
}
