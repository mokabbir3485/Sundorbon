using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_JobItemDetailsBLL
    {
        public ws_JobItemDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ws_JobItemDetailsDAO = new ws_JobItemDetailsDAO();
        }

        public ws_JobItemDetailsDAO ws_JobItemDetailsDAO { get; set; }
        public List<ws_JobItemDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return ws_JobItemDetailsDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ws_JobItemDetails> GetAllByJobNumber(string Number)
        {
            try
            {
                return ws_JobItemDetailsDAO.GetByJobNumber(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Add(ws_JobItemDetails _ws_JobItemDetails, string transactionType)
        {
            try
            {
                return ws_JobItemDetailsDAO.Post(_ws_JobItemDetails, transactionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
