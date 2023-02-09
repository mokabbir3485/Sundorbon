using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
   public class xrpt_inv_PurchaseRequisition
    {

		public string Number { get; set; }
		public DateTime RequisitionDate { get; set; }
	
		public Int32 RequestedByEmployeeId { get; set; }


		public string EmployeeName { get; set; }
		public string CounterName { get; set; }
	


	}
}
