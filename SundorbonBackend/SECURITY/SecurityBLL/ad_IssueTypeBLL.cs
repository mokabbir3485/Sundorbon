using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_IssueTypeBLL
    {
        public ad_IssueTypeBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_IssueTypeDAO = new ad_IssueTypeDAO();
        }

        public ad_IssueTypeDAO _ad_IssueTypeDAO { get; set; }

        public List<ad_IssueType> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
        string sortOrder, ref int rows)
        {
            try
            {
                return _ad_IssueTypeDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_IssueType _ad_IssueType)
        {
            try
            {
                return _ad_IssueTypeDAO.Post(_ad_IssueType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_IssueType> GetAll ()
        {
            try
            {

                return _ad_IssueTypeDAO.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
