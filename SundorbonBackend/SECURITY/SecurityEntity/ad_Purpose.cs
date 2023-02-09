using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_Purpose
	{
		public Int32 Id { get; set; }
		public string Purpose { get; set; }
		public bool IsActive { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
