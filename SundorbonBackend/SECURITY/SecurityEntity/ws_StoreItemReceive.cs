using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ws_StoreItemReceive
    {
        public string Number { get; set; }
        public DateTime ReceiveDate { get; set; }
        public Int32 ReceivedByEmployeeId { get; set; }
        public Int32 InspectedByEmployeeId { get; set; }
        public string RequistionSlipNo { get; set; }
        public string StoreIssueNumber { get; set; }
        public string ManualReferenceNumber { get; set; }
        public Int32 CounterId { get; set; }
        public string Remarks { get; set; }
        public Int32 ApprovalStatusId { get; set; }
        public Int32 CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public Int32 UpdatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string TransactiontionType { get; set; }

        public string ProductName { get; set; }
        public string StoreName { get; set; }
        public string ReceivedByEmployeeName { get; set; }
        public string InspectedByEmplyeeName { get; set; }
    }
}
