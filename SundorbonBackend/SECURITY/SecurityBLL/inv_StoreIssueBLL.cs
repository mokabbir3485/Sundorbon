using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class inv_StoreIssueBLL
    {
        public inv_StoreIssueBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _inv_StoreIssueDAO = new inv_StoreIssuesDAO();
        }

        public inv_StoreIssuesDAO _inv_StoreIssueDAO { get; set; }

        public List<inv_StoreIssue> GetAll()
        {
            try
            {
                return _inv_StoreIssueDAO.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

       // public List<inv_StoreIssue> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
       //string sortOrder, ref int rows)
       // {
       //     try
       //     {
       //         return _inv_StoreIssueDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
       //     }
       //     catch (Exception ex)
       //     {
       //         throw ex;
       //     }
       // }
        //public string Add(inv_StoreIssue inv_StoreIssue)
        //{
        //    try
        //    {
        //        return _inv_StoreIssueDAO.Post(inv_StoreIssue);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public int DetailPost(inv_StoreIssueDetail inv_StoreIssueDetail)
        //{
        //    try
        //    {
        //        return _inv_StoreIssueDAO.DetailPost(inv_StoreIssueDetail);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<inv_StoreIssueDetail> StoreReciveDetails_GetBy_Number(string number)
        //{
        //    try
        //    {
        //        return _inv_StoreIssueDAO.StoreReciveDetails_GetBy_Number(number);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
