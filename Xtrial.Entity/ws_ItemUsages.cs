using System;
using System.Text;

namespace XtrialEntity
{
	public class ws_ItemUsages
	{
		public string Number { get; set; }
		public string UsagesDate { get; set; }
		public Int32 UsagedByEmployeeId { get; set; }
		public Int32 PurposeId { get; set; }
		public Int32 VechileId { get; set; }
		public Int32 CounterId { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
