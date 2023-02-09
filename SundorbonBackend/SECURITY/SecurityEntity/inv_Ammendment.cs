using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_Ammendment
    {
		public int Id { get; set; }
		public DateTime AmendDate { get; set; }
		public int ApprovalGivenOnId  { get; set; }
		public string ReferenceTransactionNumber { get; set; }
		public int AmendmentByEmployeeId { get; set; }
		public string TransactionType { get; set; }
		public string ApprovalGivenOn { get; set; }
		public string EmployeeName { get; set; }
	
	

	}
}
