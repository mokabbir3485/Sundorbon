using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_ApprovalStatusBLL
    {
        public ad_ApprovalStatusBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ad_ApprovalStatusDAO = new ad_ApprovalStatusDAO();
        }

        public ad_ApprovalStatusDAO ad_ApprovalStatusDAO { get; set; }
        public List<ad_ApprovalStatus> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return ad_ApprovalStatusDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_ApprovalStatus> GetAll()
        {
            try
            {
                return ad_ApprovalStatusDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_ApprovalStatus _ad_VAT)
        {
            try
            {
                return ad_ApprovalStatusDAO.Post(_ad_VAT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
