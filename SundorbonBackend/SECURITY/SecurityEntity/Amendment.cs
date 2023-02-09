using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    class Amendment
    {
        public Int32 Id { get; set; }
        public DateTime AmendDate { get; set; }
        public Int32 ApprovalGivenOnId { get; set; }
        public string ReferenceTransactionNumber { get; set; }
        public Int32 AmendmentByEmployeeId { get; set; }
    }
}
