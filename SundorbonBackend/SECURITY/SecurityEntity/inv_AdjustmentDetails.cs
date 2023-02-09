using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_AdjustmentDetails
    {
        public Int32 Id { get; set; }
        public string AdjustmentNumber { get; set; }
        public Int32 RackId { get; set; }
        public Int32 ItemId { get; set; }
        public bool IsIncreased { get; set; }
        public Decimal AdjustedQty { get; set; }
        public Decimal AdjstedUnitPrice { get; set; }
        public string Remarks { get; set; }
        public string RackDescription { get; set; }
        public string ProductName { get; set; }
    }
}
