using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_StoreIssue
    {
        public string IssueNo { get; set; }
        public DateTime IssueDate { get; set; }
        public int IssuedFromStoreId { get; set; }
        public int IssuedByUserId { get; set; }
        public int IssueTypeId { get; set; }
        public int PurposeId { get; set; }
        public string ReferenceId { get; set; }
        public int CounterId { get; set; }
        public int ApprovalStatusId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Int32 UpdatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        //public int UpdatorId { get; set; }
        public string TransactiontionType { get; set; }
        public string EmployeeName { get; set; }
        public string Status { get; set; }
        public string CounterName { get; set; }

        public string RequisitionNo { get; set; }
        public DateTime RequistionDate { get; set; }
    }
}
