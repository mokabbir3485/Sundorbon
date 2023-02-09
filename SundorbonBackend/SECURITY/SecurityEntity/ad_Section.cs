using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
   public class ad_Section
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }
        public int UpdatorId { get; set; }
        public int CreatorId { get; set; }
        public string DepartmentName { get; set; }
    }
}
