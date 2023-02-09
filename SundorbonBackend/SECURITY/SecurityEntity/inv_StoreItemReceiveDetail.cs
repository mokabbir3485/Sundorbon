using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
   public class inv_StoreItemReceiveDetail
    {
        public int Id { get; set; }
        public string StoreReceiveNumber { get; set; }
        public int StockReceiveId { get; set; }
        public int StoreRackId { get; set; }
        public int ItemId { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal ReceivedUnitPrice { get; set; }
        public string CounterName { get; set; }
        public string EmployeeName { get; set; }
        public string Combination { get; set; }
        public string Number { get; set; }
        public DateTime StockReceiveDate { get; set; }
        public string UnitDescription { get; set; }
    }
}
