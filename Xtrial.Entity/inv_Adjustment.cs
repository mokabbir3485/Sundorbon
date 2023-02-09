using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_Adjustment
	{
		public string Number { get; set; }
		public string AdjustmentDate { get; set; }
		public Int32 AdjustedByUserId { get; set; }
		public string AdjustedReason { get; set; }
		public Int32 CounterId { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
