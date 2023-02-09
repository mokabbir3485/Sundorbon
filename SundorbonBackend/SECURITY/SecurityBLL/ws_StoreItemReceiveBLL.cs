using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_StoreItemReceiveBLL
    {
        public ws_StoreItemReceiveBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ws_StoreItemReceiveDAO = new ws_StoreItemReceiveDAO();
        }

        public ws_StoreItemReceiveDAO _ws_StoreItemReceiveDAO { get; set; }


        public string Add(ws_StoreItemReceive _ws_StoreItemReceive)
        {
            try
            {
                return _ws_StoreItemReceiveDAO.Post(_ws_StoreItemReceive);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ws_StoreItemReceive> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
       string sortOrder, ref int rows)
        {
            try
            {
                return _ws_StoreItemReceiveDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ws_StoreItemReceiveDetails> GetAll(string Number)
        {
            try
            {
                return _ws_StoreItemReceiveDAO.GetAll(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
