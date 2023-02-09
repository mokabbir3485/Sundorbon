using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class inv_IssueBLL
    {
        public inv_IssueBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            inv_StoreIssueDAO = new inv_StoreIssueDAO();
        }

        public inv_StoreIssueDAO inv_StoreIssueDAO { get; set; }
        public string AddStoreIssue(inv_StoreIssue _inv_StoreIssue)
        {
            try
            {
                return inv_StoreIssueDAO.AddStoreIssue(_inv_StoreIssue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_StoreIssue> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return inv_StoreIssueDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddStoreIssueDetail(inv_StoreIssueDetail _StoreIssueDetail)
        {
            try
            {
                return inv_StoreIssueDAO.AddStoreIssueDetail(_StoreIssueDetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_StoreIssueDetail> xrpt_inv_StoreIssueDetails(string number)
        {
            try
            {
                return inv_StoreIssueDAO.xrpt_inv_StoreIssueDetails(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
