using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ws_IssueItem
    {
        public string IssueNo { get; set; }
        public DateTime IssueDate { get; set; }
        public Int32 IssuedFromStoreId { get; set; }
        public Int32 IssuedByUserId { get; set; }
        public Int32 IssueTypeId { get; set; }
        public Int32 PurposeId { get; set; }
        public string ReferenceId { get; set; }
        public Int32 CounterId { get; set; }
        public Int32 ApprovalStatusId { get; set; }
        public Int32 CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Int32 UpdatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string TransactiontionType { get; set; }
        public string EmployeeName { get; set; }
        public string Status { get; set; }
        public string CounterName { get; set; }
    }
}
