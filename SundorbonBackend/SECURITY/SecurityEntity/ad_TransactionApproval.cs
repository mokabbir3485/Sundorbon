using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_TransactionApproval
	{
		public Int32 Id { get; set; }
		public Int32 DepartmentId { get; set; }
		public DateTime ApprovalDate { get; set; }
		public Int32 ApprovalStatusId { get; set; }
		public Int32 ApprovalGivenOnId { get; set; }
		public string ReferenceTransactionNumber { get; set; }
		public string Remarks { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
		public string DepartmentName { get; set; }
		public string Status { get; set; }
		public string ApprovalGivenOn { get; set; }
	}
}
