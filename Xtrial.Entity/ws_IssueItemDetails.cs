using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_IssueItemDetails
	{
		public Int32 Id { get; set; }
		public string IssueNumber { get; set; }
		public Int32 StoreId { get; set; }
		public Int32 RackId { get; set; }
		public Decimal IssuedQty { get; set; }
		public Decimal IssuedPrice { get; set; }
		public bool IsVoid { get; set; }
		public string Remarks { get; set; }
	}
}
