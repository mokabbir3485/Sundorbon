using System;
using System.Text;

namespace XtrialEntity
{
	public class s_Screen
	{
		public Int32 ScreenId { get; set; }
		public Int32 ModuleId { get; set; }
		public string ScreenName { get; set; }
		public string Description { get; set; }
		public string ScreenUrl { get; set; }
		public string ImageUrl { get; set; }
		public bool IsPage { get; set; }
		public Int32 Sorting { get; set; }
		public string MainTableName { get; set; }
	}
}
