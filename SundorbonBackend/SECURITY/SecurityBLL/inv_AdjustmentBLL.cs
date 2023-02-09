using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class inv_AdjustmentBLL
    {
        public inv_AdjustmentBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _inv_AdjustmentDAO = new inv_AdjustmentDAO();
        }

        public inv_AdjustmentDAO _inv_AdjustmentDAO { get; set; }

        public string Add(inv_Adjustment _inv_Adjustment,string transactiontionType)
        {
            try
            {
                return _inv_AdjustmentDAO.Post(_inv_Adjustment, transactiontionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_Adjustment> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _inv_AdjustmentDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_Adjustment> GetAll()
        {
            try
            {
                return _inv_AdjustmentDAO.GetALL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_Adjustment> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _inv_AdjustmentDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
