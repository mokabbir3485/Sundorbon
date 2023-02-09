using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_Job
	{
		public string Number { get; set; }
		public string JobDate { get; set; }
		public Int32 VehicleId { get; set; }
		public Int32 JobCreatedByEmployeeId { get; set; }
		public Int32 PurposeId { get; set; }
		public Int32 CounterId { get; set; }
		public string DriverInformation { get; set; }
		public string Remarks { get; set; }
		public Int32 ApprovalStatusId { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
