using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_Branch
	{
		public Int32 Id { get; set; }
		public Int32 MotherCompanyId { get; set; }
		public string BranchName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string CompanyName { get; set; }
		public Int32? CreatorId { get; set; }
		public Int32? UpdatorId { get; set; }
	}
}
