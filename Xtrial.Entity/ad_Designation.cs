using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_Designation
	{
		public Int32 DesignationId { get; set; }
		public Int32 DepartmentId { get; set; }
		public string DesignationName { get; set; }
		public string ContactNo { get; set; }
		public Int32 SerialNo { get; set; }
		public bool IsActive { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
