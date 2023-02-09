using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_Adjustment
    {
        public string Number { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public Int32 AdjustedByUserId { get; set; }
        public string AdjustedReason { get; set; }
        public Int32 CounterId { get; set; }
        public Int32 CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Int32 UpdatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CounterName { get; set; }
        public string FullName { get; set; }
    }
}
