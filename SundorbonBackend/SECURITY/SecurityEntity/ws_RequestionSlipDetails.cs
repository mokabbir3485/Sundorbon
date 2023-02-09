using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ws_RequestionSlipDetails
    {
        public int Id { get; set; }
        public string RequistionSlipNumber { get; set; }
        public int ItemId { get; set; }
        public decimal RequestedQty { get; set; }
        public decimal DamagedItemQty { get; set; }
        public string Combination { get; set; }
        public string RequistionType { get; set; }
        public string EmployeeName { get; set; }
        public string Remarks { get; set; }
        public string JobNumber { get; set; }
        public string ManualReferenceNo { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string CounterName { get; set; }
        public DateTime RequistionDate { get; set; }

        public bool IsVoide { get; set; }
}
}
