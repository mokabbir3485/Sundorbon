using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_ApprovalGivenOnBLL
    {
        public ad_ApprovalGivenOnBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ad_ApprovalGivenOnDAO = new ad_ApprovalGivenOnDAO();
        }

        public ad_ApprovalGivenOnDAO ad_ApprovalGivenOnDAO { get; set; }
        public List<ad_ApprovalGivenOn> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return ad_ApprovalGivenOnDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_ApprovalGivenOn> GetAll()
        {
            try
            {
                return ad_ApprovalGivenOnDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_ApprovalGivenOn _ad_VAT)
        {
            try
            {
                return ad_ApprovalGivenOnDAO.Post(_ad_VAT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
