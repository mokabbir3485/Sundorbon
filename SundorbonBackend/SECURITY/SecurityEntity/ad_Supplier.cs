using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ad_Supplier
    {
        public Int32 Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string BIN { get; set; }
        public string TIN { get; set; }
        public string VATRegNo { get; set; }
        public string ContactPerson { get; set; }
        public bool IsActive { get; set; }
        public Int32 CreatorId { get; set; }
        public DateTime? CreationDate { get; set; }
        public Int32 UpdatorId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatorName { get; set; }
        public string UpdatorName { get; set; }
    }
}
