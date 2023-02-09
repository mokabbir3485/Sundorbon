using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
   public class inv_StoreItemReciveBLL
    {
        public inv_StoreItemReciveBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _inv_StoreItemReciveDAO = new inv_StoreItemReceiveDAO();
        }

        public inv_StoreItemReceiveDAO _inv_StoreItemReciveDAO { get; set; }

        public List<inv_StoreItemReceive> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
       string sortOrder, ref int rows)
        {
            try
            {
                return _inv_StoreItemReciveDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Add(inv_StoreItemReceive inv_StoreItemReceive)
        {
            try
            {
                return _inv_StoreItemReciveDAO.Post(inv_StoreItemReceive);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DetailPost(inv_StoreItemReceiveDetail inv_StoreItemReceiveDetail)
        {
            try
            {
                return _inv_StoreItemReciveDAO.DetailPost(inv_StoreItemReceiveDetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<inv_StoreItemReceiveDetail> StoreReciveDetails_GetBy_Number(string number)
        {
            try
            {
                return _inv_StoreItemReciveDAO.StoreReciveDetails_GetBy_Number(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
