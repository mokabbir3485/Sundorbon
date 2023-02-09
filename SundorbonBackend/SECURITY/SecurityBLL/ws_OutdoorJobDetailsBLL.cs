using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_OutdoorJobDetailsBLL
    {
        public ws_OutdoorJobDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ws_OutdoorJobDetailsDAO = new ws_OutdoorJobDetailsDAO();
        }

        public ws_OutdoorJobDetailsDAO ws_OutdoorJobDetailsDAO { get; set; }


        //public List<ws_OutdoorJobDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
        // string sortOrder, ref int rows)
        //{
        //    try
        //    {
        //        return ws_OutdoorJobDetailsDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<wsOutDoorJobDetails> GetAll()
        {
            try
            {
                return ws_OutdoorJobDetailsDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<wsOutDoorJobDetails> GetAllByJobNumber(string Number)
        {
            try
            {
                return ws_OutdoorJobDetailsDAO.GetAllByJobNumber(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Add(wsOutDoorJobDetails _ws_OutdoorJobDetails, string transactionType)
        {
            try
            {
                return ws_OutdoorJobDetailsDAO.Post(_ws_OutdoorJobDetails, transactionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
