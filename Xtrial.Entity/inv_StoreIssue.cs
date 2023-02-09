using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_StoreIssue
	{
		public string IssueNo { get; set; }
		public DateTime IssueDate { get; set; }
		public Int32 IssuedFromStoreId { get; set; }
		public Int32 IssuedByUserId { get; set; }
		public Int32 IssueTypeId { get; set; }
		public string ReferenceId { get; set; }
		public Int32 CounterId { get; set; }
		public Int32? ApprovalStatusId { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
