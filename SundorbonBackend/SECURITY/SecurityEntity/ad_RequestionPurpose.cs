using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ad_RequestionPurpose
    {
        public int Id { get; set; }
        public string Purpose { get; set; }
        public bool IsActive { get; set; }
        public int CreatorId { get; set; }
        public int UpdatorId  { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
       

    }
}
