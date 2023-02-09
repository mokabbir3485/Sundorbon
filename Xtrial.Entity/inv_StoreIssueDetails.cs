using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_StoreIssueDetails
	{
		public Int32 Id { get; set; }
		public string IssueNumber { get; set; }
		public Int32 RackId { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal IssuedQty { get; set; }
		public Decimal IssuedPrice { get; set; }
		public string Remarks { get; set; }
	}
}
