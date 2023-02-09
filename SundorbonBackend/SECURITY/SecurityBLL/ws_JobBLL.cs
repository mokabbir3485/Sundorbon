using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_JobBLL
    {
        public ws_JobBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ws_JobDAO = new ws_JobDAO();
        }

        public ws_JobDAO ws_JobDAO { get; set; }
        public List<ws_Job> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return ws_JobDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public List<ws_Job> GetAll()
        {
            try
            {
                return ws_JobDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ws_Job> GetAllPending()
        {
            try
            {
                return ws_JobDAO.GetAllPendingJob();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ws_JobItemDetails> GetAllJobItem(string Number)
        {
            try
            {
                return ws_JobDAO.GetAllJobItem(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<ws_Job> GetAll()
        //{
        //    try
        //    {
        //        return ws_JobDAO.();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public string Add(ws_Job _ws_Job,string transactionType)
        {
            try
            {
                return ws_JobDAO.Post(_ws_Job, transactionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
