using System;
using System.Text;

namespace XtrialEntity
{
	public class ad_Employee
	{
		public Int32 EmployeeId { get; set; }
		public Int32 DepartmentId { get; set; }
		public Int32 DesignationId { get; set; }
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string EmployeeCode { get; set; }
		public string ContactNo { get; set; }
		public string Email { get; set; }
		public string Gender { get; set; }
		public string PresentAddress { get; set; }
		public DateTime DateOfBirth { get; set; }
		public bool IsUser { get; set; }
		public Int32? GradeId { get; set; }
		public Int32? SectionId { get; set; }
		public Int32? ManagerId { get; set; }
		public string BloodGroup { get; set; }
		public bool? IsFlexibleOnDate { get; set; }
		public bool? IsFlexibleOnTime { get; set; }
		public Decimal? BasicSalary { get; set; }
		public DateTime? JoiningDate { get; set; }
		public DateTime? FinishDate { get; set; }
		public bool IsActive { get; set; }
		public Int32 CreatorId { get; set; }
		public DateTime CreateDate { get; set; }
		public Int32 UpdatorId { get; set; }
		public DateTime UpdateDate { get; set; }
		public Int32? ContractTypeId { get; set; }
	}
}
