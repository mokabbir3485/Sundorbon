using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_OpeingStock
	{
		public Int32 Id { get; set; }
		public Int32 StoreId { get; set; }
		public Int32 RackId { get; set; }
		public string OpeningDate { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal OpeningQty { get; set; }
		public Decimal OpeningUnitPrice { get; set; }
		public Decimal DamagedItemQty { get; set; }
		public Decimal DemagedItemUnitPrice { get; set; }
	}
}
