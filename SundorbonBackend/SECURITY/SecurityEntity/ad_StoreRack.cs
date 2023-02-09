using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_StoreRack
	{
		public Int32 Id { get; set; }
		public Int32 StoreId { get; set; }
		public string RackDescription { get; set; }
		public bool IsActive { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
		public string StoreName { get; set; }
	}
}
