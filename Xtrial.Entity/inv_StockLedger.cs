using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_StockLedger
	{
		public Int32 Id { get; set; }
		public Int32 StoreId { get; set; }
		public Int32 RackId { get; set; }
		public string TransactionDate { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal OpeingStockQty { get; set; }
		public Decimal OpeningStockUnitPrice { get; set; }
		public Decimal StockReceiveQty { get; set; }
		public Decimal StockReceiveUnitPrice { get; set; }
		public Decimal StockIssueQty { get; set; }
		public Decimal StockIssueUnitPrice { get; set; }
		public Decimal StockAdjustedIncrementQty { get; set; }
		public Decimal? StockAdjustedIncrementUnitPrice { get; set; }
		public Decimal StockAdjustedDecrementQty { get; set; }
		public Decimal? StockAdjustedDecrementUnitPrice { get; set; }
		public Decimal ClosingStockQty { get; set; }
		public Decimal ClosingUnitPrice { get; set; }
	}
}
