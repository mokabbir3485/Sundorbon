using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_StoreItemReceive
	{
		public string Number { get; set; }
		public string ReceiveDate { get; set; }
		public Int32 ReceivedByEmployeeId { get; set; }
		public Int32 InspectedByEmployeeId { get; set; }
		public string RequistionSlipNo { get; set; }
		public string StoreIssueNumber { get; set; }
		public string ManualReferenceNumber { get; set; }
		public Int32? CounterId { get; set; }
		public string Remarks { get; set; }
		public Int32? ApprovalStatusId { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
