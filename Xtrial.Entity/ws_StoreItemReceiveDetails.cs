using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_StoreItemReceiveDetails
	{
		public Int32 Id { get; set; }
		public string StoreReceiveNumber { get; set; }
		public Int32 StoreId { get; set; }
		public Int32 RackId { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal ReceiveQty { get; set; }
		public Decimal ReceivedPrice { get; set; }
		public bool IsVoid { get; set; }
		public string Remarks { get; set; }
	}
}
