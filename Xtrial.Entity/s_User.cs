using System;
using System.Text;

namespace XtrialEntity
{
	public class s_User
	{
		public Int32 UserId { get; set; }
		public Int32 EmployeeId { get; set; }
		public Int32 RoleId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public bool IsReqSmsCode { get; set; }
		public string SmsMobileNo { get; set; }
		public string AuthorizationPassword { get; set; }
		public bool IsActive { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}
