using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
   public class ad_Get_Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string BIN { get; set; }
        public string TIN { get; set; }
        public string VATRegNo { get; set; }
        public string ContactPerson { get; set; }
        public bool IsActive { get; set; }
    }
}
