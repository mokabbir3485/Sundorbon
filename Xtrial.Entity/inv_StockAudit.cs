using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_StockAudit
	{
		public Int32 Id { get; set; }
		public string AuditDate { get; set; }
		public Int32 AuditedStoreId { get; set; }
		public Int32 AuditedByUserId { get; set; }
		public string Remarks { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
