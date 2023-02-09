using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_StoreItemReceiveDetails
	{
		public Int32 Id { get; set; }
		public string StoreReceiveNumber { get; set; }
		public Int32 StoreReceiveId { get; set; }
		public Int32 StoreRackId { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal ReceivedQty { get; set; }
		public Decimal ReceivedUnitPrice { get; set; }
	}
}
