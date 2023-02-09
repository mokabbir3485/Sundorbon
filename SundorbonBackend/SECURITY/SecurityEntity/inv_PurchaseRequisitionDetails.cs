using System;
using System.Text;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
	public class inv_PurchaseRequisitionDetails
	{
		public Int32 Id { get; set; }
		public string PurchaseRequisitionNumber { get; set; }
		//public int? PurchaseRequisitionId { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal RequestedQty { get; set; }
		public bool? IsVoid { get; set; }
		public string Remarks { get; set; }
		//public Int32? MeasurmentUnitId { get; set; }
		public string Combination { get; set; }
		//public string Name { get; set; }
		//public string UnitDescription { get; set; }
		public DateTime RequisitionDate { get; set; }
		public int PurchaseVatId { get; set; }
		public string Number { get; set; }
		public string EmployeeName { get; set; }
		public string UnitDescription { get; set; }
		
		public DateTime BillDate { get; set; }

	}
}
