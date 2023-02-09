using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_StockAuditDetails
	{
		public Int32 Id { get; set; }
		public Int32 StockAuditId { get; set; }
		public Int32 RackId { get; set; }
		public Decimal PhysicalStockQty { get; set; }
		public Decimal OldStockQty { get; set; }
	}
}
