using System;
using System.Text;

namespace XtrialEntity
{
	public class s_Role
	{
		public Int32 RoleId { get; set; }
		public string RoleName { get; set; }
		public bool IsActive { get; set; }
		public bool IsSuperAdmin { get; set; }
		public bool IsCheckoutOperator { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
