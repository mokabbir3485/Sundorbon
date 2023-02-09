using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class inv_StockAuditBLL
    {
        public inv_StockAuditBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _inv_StockAuditDAO = new inv_StockAuditDAO();
        }

        public inv_StockAuditDAO _inv_StockAuditDAO { get; set; }

        public string Add(inv_StockAudit _inv_StockAudit,string transactionType)
        {
            try
            {
                return _inv_StockAuditDAO.Post(_inv_StockAudit, transactionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_StockAudit> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _inv_StockAuditDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_StockAudit> GetAll()
        {
            try
            {
                return _inv_StockAuditDAO.GetALL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_StockAudit> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _inv_StockAuditDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
