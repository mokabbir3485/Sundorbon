using System;
using System.Text;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
	public class inv_PurchaseRequisition
	{
		
		public string Number { get; set; }
		public DateTime RequisitionDate { get; set; }
		public Int32 CounterId { get; set; }
        public Int32 PurposeId { get; set; }
        public Int32 RequestedByEmployeeId { get; set; }
		public Int32 ApprovalStatusId { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }

		public string EmployeeName { get; set; }
		public string CounterName { get; set; }
		public string Status { get; set; }
		public string TransactiontionType { get; set; }
		public string DetailNumber { get; set; }
		public string ShortCode { get; set; }
		public string Purpose { get; set; }
	}
}
