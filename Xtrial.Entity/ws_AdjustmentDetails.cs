using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_AdjustmentDetails
	{
		public Int32 Id { get; set; }
		public string AdjustmentNumber { get; set; }
		public Int32 RackId { get; set; }
		public Int32 ItemId { get; set; }
		public bool IsIncreased { get; set; }
		public Decimal AdjustedQty { get; set; }
		public Decimal AdjstedUnitPrice { get; set; }
		public string Remarks { get; set; }
	}
}
