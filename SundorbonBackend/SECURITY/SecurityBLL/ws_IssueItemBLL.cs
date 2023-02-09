
using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_IssueItemBLL
    {
        public ws_IssueItemBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ws_IssueItemDAO = new ws_IssueItemDAO();
        }

        public ws_IssueItemDAO _ws_IssueItemDAO { get; set; }
        public List<ws_IssueItem> GetAll()
        {
            try
            {
                return _ws_IssueItemDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
