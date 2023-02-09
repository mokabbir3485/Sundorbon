using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_StoreBLL
    {
        public ad_StoreBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ad_StoreDAODAO = new ad_StoreDAO();
        }

        public ad_StoreDAO ad_StoreDAODAO { get; set; }

        public List<ad_Store> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
        string sortOrder, ref int rows)
        {
            try
            {
                return ad_StoreDAODAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Store> GetAll()
        {
            try
            {
                return ad_StoreDAODAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_StoreRack> GetAllRack()
        {
            try
            {
                return ad_StoreDAODAO.GetAllRack();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int Add(ad_Store ad_Store)
        {
            try
            {
                return ad_StoreDAODAO.Post(ad_Store);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
