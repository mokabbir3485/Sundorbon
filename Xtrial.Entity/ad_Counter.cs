using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_Counter
	{
		public Int32 Id { get; set; }
		public string CounterName { get; set; }
		public Int32 DepartmentId { get; set; }
		public string IPAddress { get; set; }
		public string ShortCode { get; set; }
		public bool? IsActive { get; set; }
	}
}
