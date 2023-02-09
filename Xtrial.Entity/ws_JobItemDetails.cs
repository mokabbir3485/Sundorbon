using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_JobItemDetails
	{
		public Int32 Id { get; set; }
		public string JobNumber { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal ItemRequiredFromStoreQty { get; set; }
		public Decimal ItemReusableQty { get; set; }
		public Decimal ItemDamagedQty { get; set; }
		public bool IsVoid { get; set; }
		public string Remarks { get; set; }
	}
}
