using DbExecutor;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
    public class ad_ItemReportDAO
    {
        private static volatile ad_ItemReportDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public ad_ItemReportDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }
        public static ad_ItemReportDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new ad_ItemReportDAO();
                    }

                return instance;
            }
        }

        public static ad_ItemReportDAO GetInstance()
        {
            if (instance == null) instance = new ad_ItemReportDAO();
            return instance;
        }

        public List<ad_ItemReport> GetAll(int? modelId=null, string groupName=null)
        {
            try
            {
                Parameters[] colparameters = new Parameters[2]{
                new Parameters("@ModelId",modelId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@GroupName", groupName, DbType.String, ParameterDirection.Input)
                };
                var ad_ItemReportLst = new List<ad_ItemReport>();
                ad_ItemReportLst =
                    dbExecutor.FetchData<ad_ItemReport>(CommandType.StoredProcedure, "ad_rpt_ItemList", colparameters);
                return ad_ItemReportLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
