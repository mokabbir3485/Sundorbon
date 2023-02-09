using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_SupplierBLL
    {
        public ad_SupplierDAO _ad_SupplierDAO { get; set; }
        public ad_SupplierBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_SupplierDAO = new ad_SupplierDAO();
        }

        public List<ad_Supplier> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_SupplierDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_Supplier _ad_Item)
        {
            try
            {
                return _ad_SupplierDAO.Post(_ad_Item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Get_Supplier> GetAll()
        {
            try
            {
                return _ad_SupplierDAO.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
