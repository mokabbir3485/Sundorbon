using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_PurchaseRequisitionDetails
	{
		public Int32 Id { get; set; }
		public string PurchaseRequisitionNumber { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal RequestedQty { get; set; }
		public bool? IsVoid { get; set; }
		public string Remarks { get; set; }
	}
}
