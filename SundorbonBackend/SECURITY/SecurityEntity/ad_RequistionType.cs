using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_RequistionType
	{
		public Int32 Id { get; set; }
		public string RequistionType { get; set; }
		public bool IsActive { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
