using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_VAT
	{
		public Int32 Id { get; set; }
		public string VatPercent { get; set; }
		public Decimal PercentNumber { get; set; }
		public bool? IsActive { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
