﻿using DbExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class ad_Designation : IEntityBase
    {
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public string DesignationName { get; set; }
        public string ContactNo { get; set; }
        public int SerialNo { get; set; }
        public bool IsActive { get; set; }
        public string DepartmentName { get; set; }
        //public string Status { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdatorId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
