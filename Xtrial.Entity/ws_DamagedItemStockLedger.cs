using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_DamagedItemStockLedger
	{
		public Int32 Id { get; set; }
		public Int32 DStoreId { get; set; }
		public Int32 DRackId { get; set; }
		public string DTransactionDate { get; set; }
		public Int32 DItemId { get; set; }
		public Decimal DOpeingStockQty { get; set; }
		public Decimal DOpeningStockUnitPrice { get; set; }
		public Decimal DStockReceiveQty { get; set; }
		public Decimal DStockReceiveUnitPrice { get; set; }
		public Decimal DStockIssueQty { get; set; }
		public Decimal DStockIssueUnitPrice { get; set; }
		public Decimal DStockAdjustedIncrementQty { get; set; }
		public Decimal? DStockAdjustedIncrementUnitPrice { get; set; }
		public Decimal DStockAdjustedDecrementQty { get; set; }
		public Decimal? DStockAdjustedDecrementUnitPrice { get; set; }
		public Decimal DClosingStockQty { get; set; }
		public Decimal DClosingUnitPrice { get; set; }
	}
}
