using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_AmmendmentDetails
    {

		public int Id { get; set; }
		public int AmmendmentId { get; set; }
		public decimal AmendedQuantity { get; set; }
		public decimal AmendedPrice { get; set; }
		public string Remarks { get; set; }
		public decimal Vat { get; set; }
		public decimal AIT { get; set; }
		public decimal SD { get; set; }
		public int ItemId { get; set; }
        public DateTime AmendDate { get; set; }
		public string EmployeeName { get; set; }
		public string Combination { get; set; }
        public int DetailId { get; set; }


    }
}
