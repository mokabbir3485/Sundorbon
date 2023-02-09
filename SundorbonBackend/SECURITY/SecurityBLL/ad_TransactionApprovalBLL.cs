using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_TransactionApprovalBLL
    {
        public ad_TransactionApprovalBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ad_TransactionApprovalDAO = new ad_TransactionApprovalDAO();
        }

        public ad_TransactionApprovalDAO ad_TransactionApprovalDAO { get; set; }
        public List<ad_TransactionApproval> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return ad_TransactionApprovalDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_TransactionApproval _ad_VAT)
        {
            try
            {
                return ad_TransactionApprovalDAO.Post(_ad_VAT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
        public List<TransactionApproveTablename> GetTableName(string TableName, DateTime? FromDate, DateTime? ToDate)
        {
            try
            {
                return ad_TransactionApprovalDAO.GetNumber(TableName, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
