using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_Vehicle
	{
		public Int32 Id { get; set; }
		public string VehicleNo { get; set; }
		public string EngineNo { get; set; }
		public string ChasisNo { get; set; }
		public string ModelId { get; set; }
		public Int32 VehicleGroupId { get; set; }
		public bool IsActive { get; set; }
		public bool IsOwnership { get; set; }
        public string Name { get; set; }
		public Int32 EmployeeId { get; set; }
		public Int32 CreatorId { get; set; }
		public Int32 UpdatorId { get; set; }
		public string Username { get; set; }
		public string GroupName { get; set; }

	}
}
