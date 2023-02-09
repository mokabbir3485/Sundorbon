using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_Supplier
	{
		public Int32 Id { get; set; }
		public string SupplierName { get; set; }
		public string Address { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
		public string BIN { get; set; }
		public string TIN { get; set; }
		public string VATRegNo { get; set; }
		public string ContactPerson { get; set; }
		public bool IsActive { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
