using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_Item
	{
		public Int32 Id { get; set; }
		public string ItemCode { get; set; }
		public string ProductName { get; set; }
		public Int32 ModelId { get; set; }
		public Int32 ItemGroupId { get; set; }
		public Int32 MeasureUnitId { get; set; }
		public Int32 PurchaseVatId { get; set; }
		public Int32 SupplimentaryDutyId { get; set; }
		public bool HasExpiry { get; set; }
		public Decimal ROL { get; set; }
		public bool IsActive { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
