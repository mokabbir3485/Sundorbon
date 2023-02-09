using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_ApprovalGivenOn
	{
		public Int32 Id { get; set; }
		public string ApprovalGivenOn { get; set; }
		public bool IsActive { get; set; }
        public Int32 CreatorId { get; set; }
		public Int32 UpdatorId { get; set; }
	}
}
