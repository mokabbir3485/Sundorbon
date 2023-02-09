using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class inv_PurchaseRequisitionDetailsBLL
    {
        public inv_PurchaseRequisitionDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _inv_PurchaseRequisitionDetailsDAO = new inv_PurchaseRequisitionDetailsDAO();
        }

        public inv_PurchaseRequisitionDetailsDAO _inv_PurchaseRequisitionDetailsDAO { get; set; }

        public int Add(inv_PurchaseRequisitionDetails _inv_PurchaseRequisitionDetails)
        {
            try
            {
                return _inv_PurchaseRequisitionDetailsDAO.Post(_inv_PurchaseRequisitionDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddIntoPurchaseRequisitionDetailsLog(inv_PurchaseRequisitionDetails _inv_PurchaseRequisitionDetails,string TransactionType)
        {
            try
            {
                return _inv_PurchaseRequisitionDetailsDAO.PostIntoPurchaseRequisitionDetailsLog(_inv_PurchaseRequisitionDetails, TransactionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_PurchaseRequisitionDetails> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _inv_PurchaseRequisitionDetailsDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<inv_PurchaseRequisitionDetails> GetAll()
        //{
        //    try
        //    {
        //        return _inv_PurchaseRequisitionDetailsDAO.GetAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<inv_PurchaseRequisitionDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _inv_PurchaseRequisitionDetailsDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
