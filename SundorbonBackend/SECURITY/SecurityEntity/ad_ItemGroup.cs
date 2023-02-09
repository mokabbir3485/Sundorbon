using System;
using System.Text;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
	public class ad_ItemGroup
	{
		public Int32 Id { get; set; }
		public string GroupName { get; set; }
		public bool IsActive { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
