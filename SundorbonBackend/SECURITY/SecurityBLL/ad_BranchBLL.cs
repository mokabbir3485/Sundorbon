using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_BranchBLL
    {
        public ad_BranchBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_BranchDAO = new ad_BranchDAO();
        }

        public ad_BranchDAO _ad_BranchDAO { get; set; }
        public List<ad_Branch> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_BranchDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Branch> GetAll()
        {
            try
            {
                return _ad_BranchDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_Branch _ad_Branch)
        {
            try
            {
                return _ad_BranchDAO.Post(_ad_Branch);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
