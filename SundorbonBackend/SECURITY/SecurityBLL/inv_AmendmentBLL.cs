using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class inv_AmendmentBLL
    {
        public inv_AmendmentBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            inv_AmendmentDAO = new inv_AmendmentDAO();
        }

        public inv_AmendmentDAO inv_AmendmentDAO { get; set; }
        public List<inv_Ammendment> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return inv_AmendmentDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_Ammendment> GetAll()
        {
            try
            {
                return inv_AmendmentDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(inv_Ammendment _inv_Ammendment)
        {
            try
            {
                return inv_AmendmentDAO.AddAmmendment(_inv_Ammendment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
