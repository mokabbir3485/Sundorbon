using System;
using System.Text;

namespace XtrialEntity
{
	public class s_Module
	{
		public Int32 ModuleId { get; set; }
		public Int32 DomainId { get; set; }
		public string ModuleName { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
