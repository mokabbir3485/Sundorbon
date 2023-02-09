using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_DemagedItemStockLedger
	{
		public Int32 Id { get; set; }
		public Int32 OStoreId { get; set; }
		public Int32 ORackId { get; set; }
		public string OTransactionDate { get; set; }
		public Int32 OItemId { get; set; }
		public Decimal OOpeingStockQty { get; set; }
		public Decimal OOpeningStockUnitPrice { get; set; }
		public Decimal OStockReceiveQty { get; set; }
		public Decimal OStockReceiveUnitPrice { get; set; }
		public Decimal OStockIssueQty { get; set; }
		public Decimal OStockIssueUnitPrice { get; set; }
		public Decimal OStockAdjustedIncrementQty { get; set; }
		public Decimal? OStockAdjustedIncrementUnitPrice { get; set; }
		public Decimal OStockAdjustedDecrementQty { get; set; }
		public Decimal? OStockAdjustedDecrementUnitPrice { get; set; }
		public Decimal OClosingStockQty { get; set; }
		public Decimal OClosingUnitPrice { get; set; }
	}
}
