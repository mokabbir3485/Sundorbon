using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_PurchaseRequisition
	{
		public string Number { get; set; }
		public string RequisitionDate { get; set; }
		public Int32 CounterId { get; set; }
		public Int32 RequestedByEmployeeId { get; set; }
		public Int32 ApprovalStatusId { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
