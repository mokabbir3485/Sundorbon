using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
   public class inv_StoreIssueDetail
    {
        public int Id { get; set; }
        public string IssueNumber { get; set; }
        public int RackId { get; set; }
        public int ItemId { get; set; }
        public decimal IssuedQty { get; set; }
        public decimal IssuedPrice { get; set; }
        public string Remarks { get; set; }
        public string RackDescription { get; set; }
        public string UnitDescription { get; set; }
        public string Combination { get; set; }
        public string StoreName { get; set; }
        public string EmployeeName { get; set; }
        public string CounterName { get; set; }
        public string IssueNo { get; set; }
        public string Purpose { get; set; }
        public string IssueType { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
