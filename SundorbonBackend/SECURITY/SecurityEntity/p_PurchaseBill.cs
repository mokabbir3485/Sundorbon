using System;
using System.Text;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
	public class p_PurchaseBill
	{
		public string Number { get; set; }
		public DateTime BillDate { get; set; }
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
		public string  TransactionType { get; set; }
		public string SupplierName { get; set; }
		public string CounterName { get; set; }
		public string Status { get; set; }
	}
}
