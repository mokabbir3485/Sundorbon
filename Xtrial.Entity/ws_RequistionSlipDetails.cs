using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_RequistionSlipDetails
	{
		public Int32 Id { get; set; }
		public string RequistionSlipNumber { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal RequestedQty { get; set; }
		public Decimal? DamagedItemQty { get; set; }
		public string Remarks { get; set; }
		public bool IsVoid { get; set; }
	}
}
