using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_ItemUsagesDetails
	{
		public Int32 Id { get; set; }
		public string UsagesNumber { get; set; }
		public Int32 StoreId { get; set; }
		public Int32 RackId { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal UsageQty { get; set; }
		public Decimal UsagedPriced { get; set; }
		public bool IsVoid { get; set; }
		public string Remarks { get; set; }
	}
}
