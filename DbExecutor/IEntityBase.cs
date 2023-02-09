using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExecutor
{
    public interface IEntityBase
    {
        int CreatorId { get; set; }
        DateTime CreateDate { get; set; }
        int UpdatorId { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
