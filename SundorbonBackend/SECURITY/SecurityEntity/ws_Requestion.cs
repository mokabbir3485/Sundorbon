using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ws_Requestion
    {

        public DateTime RequistionDate { get; set; }
        public Int32 CounterId { get; set; }
        public string JobNumber { get; set; }
        public string Number { get; set; }
        public string ManualReferenceNo { get; set; }
        public int RequistionGivenByEmployeeId { get; set; }
        public int RequistionSlipTypeId { get; set; }
        public string Remarks { get; set; }
        public int ApprovalStatusId { get; set; }

        public int SlipAdjForDriverEmloyeeId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string EmployeeName { get; set; }
        public string Status { get; set; }
        public string CounterName { get; set; }
        public string TransactiontionType { get; set; }
        public string BranchName { get; set; }

    }
}
