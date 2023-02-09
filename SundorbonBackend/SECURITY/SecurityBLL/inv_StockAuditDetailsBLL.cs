using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class inv_StockAuditDetailsBLL
    {
        public inv_StockAuditDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _inv_StockAuditDetailsDAO = new inv_StockAuditDetailsDAO();
        }

        public inv_StockAuditDetailsDAO _inv_StockAuditDetailsDAO { get; set; }

        public int Add(inv_StockAuditDetails _inv_StockAuditDetails)
        {
            try
            {
                return _inv_StockAuditDetailsDAO.Post(_inv_StockAuditDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_StockAuditDetails> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _inv_StockAuditDetailsDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_StockAuditDetails> GetAllStockAuditDetailsFromStockAuditId(string Id)
        {
            try
            {
                return _inv_StockAuditDetailsDAO.GetAllAdjustmentDetailsFromAdjustmentId(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_StockAuditDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _inv_StockAuditDetailsDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
