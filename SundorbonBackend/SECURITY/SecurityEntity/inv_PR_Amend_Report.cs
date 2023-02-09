using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_PR_Amend_Report
    {
        public string PurchaseRequisitionNumber { get; set; }
        public string Expr1 { get; set; }
        public Int32 Expr2 { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 Expr3 { get; set; }
        public Decimal amendqty { get; set; }
        public Decimal req_qty { get; set; }
        public string Remarks { get; set; }
        public Int32 MeasurmentUnitId { get; set; }
        public string Expr5 { get; set; }
        public string Expr6 { get; set; }
        public Int32 Id { get; set; }
        public string Combination { get; set; }

    }
}
