using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_IssueItemDetailsBLL
    {
        public ws_IssueItemDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ws_IssueItemDAO = new ws_IssueItemDetailsDAO();
        }

        public ws_IssueItemDetailsDAO _ws_IssueItemDAO { get; set; }
        public List<ws_IssueItemDetails> GetAll(string Number)
        {
            try
            {
                return _ws_IssueItemDAO.GetAll(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
