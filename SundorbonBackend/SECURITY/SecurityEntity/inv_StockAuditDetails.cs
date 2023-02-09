using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_StockAuditDetails
    {
        public Int32 Id { get; set; }
        public string StockAuditId { get; set; }
        public Int32 RackId { get; set; }
        public Decimal PhysicalStockQty { get; set; }
        public Decimal OldStockQty { get; set; }
        public string RackDescription { get; set; }
    }
}
