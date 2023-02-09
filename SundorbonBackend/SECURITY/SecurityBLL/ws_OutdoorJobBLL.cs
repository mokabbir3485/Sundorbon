using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_OutdoorJobBLL
    {
        public ws_OutdoorJobBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ws_OutdoorJobDAO = new ws_OutdoorJobDAO();
        }

        public ws_OutdoorJobDAO ws_OutdoorJobDAO { get; set; }
        public List<ws_OutdoorJob> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return ws_OutdoorJobDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public List<ws_OutdoorJob> GetAllPending()
        {
            try
            {
                return ws_OutdoorJobDAO.GetAllPendingJob();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ws_OutdoorJobItemDetails> GetAllJobItem(string Number)
        {
            try
            {
                return ws_OutdoorJobDAO.GetAllJobItem(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<ws_OutdoorJob> GetAll()
        //{
        //    try
        //    {
        //        return ws_OutdoorJobDAO.();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public string Add(ws_OutdoorJob _ws_OutdoorJob, string transactionType)
        {
            try
            {
                return ws_OutdoorJobDAO.Post(_ws_OutdoorJob, transactionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
