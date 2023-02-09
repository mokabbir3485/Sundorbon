using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_StoreRackBLL
    {
        public ad_StoreRackBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_StoreRackDAO = new ad_StoreRackDAO();
        }

        public ad_StoreRackDAO _ad_StoreRackDAO { get; set; }

        public List<ad_StoreRack> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
        string sortOrder, ref int rows)
        {
            try
            {
                return _ad_StoreRackDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_StoreRack> GetByStoreId(int Id)
        {
            try
            {
                return _ad_StoreRackDAO.GetByStoreId(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_StoreRack> GetAll()
        {
            try
            {
                return _ad_StoreRackDAO.GetALL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_StoreRack ad_StoreRack)
        {
            try
            {
                return _ad_StoreRackDAO.Post(ad_StoreRack);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
