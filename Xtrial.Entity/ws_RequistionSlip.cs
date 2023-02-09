using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_RequistionSlip
	{
		public string Number { get; set; }
		public string RequistionDate { get; set; }
		public Int32 CounterId { get; set; }
		public string JobNumber { get; set; }
		public string ManualReferenceNo { get; set; }
		public Int32 RequistionGivenByEmployeeId { get; set; }
		public Int32 RequistionSlipTypeId { get; set; }
		public string Remarks { get; set; }
		public Int32? ApprovalStatusId { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
