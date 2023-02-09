using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ws_OutdoorJob
    {
        public string Number { get; set; }
        public DateTime OutdoorJobDate { get; set; }
        public Int32 VehicleId { get; set; }
        public Int32 JobCreatedByEmployeeId { get; set; }
        public Int32 PurposeId { get; set; }
        public Int32 CounterId { get; set; }
        public string VendorName { get; set; }
        public string DriverInformation { get; set; }
        public string Remarks { get; set; }
        public Int32 ApprovalStatusId { get; set; }
        public Int32 CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public Int32 UpdatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string VehicleNo { get; set; }
        //public string Combination { get; set; }
        public string Purpose { get; set; }
        public string CounterName { get; set; }
        public string Status { get; set; }

        public string EmployeeName { get; set; }
        public string transactionType { get; set; } = null;
    }
}
