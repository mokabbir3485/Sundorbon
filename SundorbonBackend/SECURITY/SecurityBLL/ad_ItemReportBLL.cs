using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_ItemReportBLL
    {
        public ad_ItemReportDAO _ad_ItemReportDao { get; set; }
        public ad_ItemReportBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_ItemReportDao = new ad_ItemReportDAO();
        }
        public List<ad_ItemReport> GetAll(int? modelId = null, string groupName = null)
        {
            try
            {
                return _ad_ItemReportDao.GetAll(modelId, groupName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
