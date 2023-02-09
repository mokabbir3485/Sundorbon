using System;
using System.Text;

namespace XtrialEntity
{
	public class p_PurchaseBill
	{
		public string Number { get; set; }
		public string BillDate { get; set; }
		public string PurchaseRequisitionNumber { get; set; }
		public string ManualBillNo { get; set; }
		public Int32 SupplierId { get; set; }
		public Int32 ApprovalStatusId { get; set; }
		public string Remarks { get; set; }
		public Int32? CounterId { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
