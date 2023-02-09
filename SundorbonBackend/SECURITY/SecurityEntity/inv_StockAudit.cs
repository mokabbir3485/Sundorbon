using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_StockAudit
    {
        public string Id { get; set; }
        public DateTime AuditDate { get; set; }
        public Int32 AuditedStoreId { get; set; }
        public Int32 AuditedByUserId { get; set; }
        public string Remarks { get; set; }
        public Int32 CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Int32 UpdatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StoreName { get; set; }
        public string FullName { get; set; }
    }
}
