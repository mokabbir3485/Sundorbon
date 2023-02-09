using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_RequestionBLL
    {
        public ws_RequestionBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
           _ws_RequestionDAO = new ws_RequestionDAO();
        }

        public ws_RequestionDAO _ws_RequestionDAO { get; set; }


        public string Add(ws_Requestion _ws_Requestion)
        {
            try
            {
                return _ws_RequestionDAO.Post(_ws_Requestion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ws_Requestion> GetAllRequisitionSlip()
        {
            try
            {
                return _ws_RequestionDAO.GetAllRequestionSlip();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddDetail(ws_RequestionSlipDetails _RequestionSlipDetails)
        {
            try
            {
                return _ws_RequestionDAO.WsDetailAdd(_RequestionSlipDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      public List<ws_Requestion> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
       string sortOrder, ref int rows)
        {
            try
            {
                return _ws_RequestionDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ws_Requestion> ws_RequistionSlip_GetByIssue(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                return _ws_RequestionDAO.ws_RequistionSlip_GetByIssue(fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ws_RequestionSlipDetails> GetByWSRequisitionNumber(string number)
        {
            try
            {
                return _ws_RequestionDAO.GetByWSRequisitionNumber(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ws_RequestionSlipDetails> GetByWSRequisitionReport(string number)
        {
            try
            {
                return _ws_RequestionDAO.GetByWSRequisitionReport(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
