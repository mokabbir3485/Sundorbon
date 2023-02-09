using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_JobDetailsBLL
    {
        public ws_JobDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ws_JobDetailsDAO = new ws_JobDetailsDAO();
        }

        public ws_JobDetailsDAO ws_JobDetailsDAO { get; set; }
        //public List<ws_JobDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
        // string sortOrder, ref int rows)
        //{
        //    try
        //    {
        //        return ws_JobDetailsDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<ws_JobDetails> GetAll()
        {
            try
            {
                return ws_JobDetailsDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ws_JobDetails> GetAllByJobNumber(string Number)
        {
            try
            {
                return ws_JobDetailsDAO.GetAllByJobNumber(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Add(ws_JobDetails _ws_JobDetails, string transactionType)
        {
            try
            {
                return ws_JobDetailsDAO.Post(_ws_JobDetails, transactionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
