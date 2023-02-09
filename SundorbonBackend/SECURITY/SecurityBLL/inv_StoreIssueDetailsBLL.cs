using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class inv_StoreIssueDetailsBLL
    {
        public inv_StoreIssueDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _inv_StoreIssueDetailsDAO = new inv_StoreIssueDetailsDAO();
        }

        public inv_StoreIssueDetailsDAO _inv_StoreIssueDetailsDAO { get; set; }

        public List<inv_StoreIssueDetails> GetByStoreIssueNumber(string Number)
        {
            try
            {
                return _inv_StoreIssueDetailsDAO.GetByStoreIssueNumber(Number);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
