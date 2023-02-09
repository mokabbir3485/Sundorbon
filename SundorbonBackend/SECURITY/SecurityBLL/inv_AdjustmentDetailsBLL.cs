using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class inv_AdjustmentDetailsBLL
    {
        public inv_AdjustmentDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _inv_AdjustmentDetailsDAO = new inv_AdjustmentDetailsDAO();
        }

        public inv_AdjustmentDetailsDAO _inv_AdjustmentDetailsDAO { get; set; }

        public int Add(inv_AdjustmentDetails _inv_AdjustmentDetails)
        {
            try
            {
                return _inv_AdjustmentDetailsDAO.Post(_inv_AdjustmentDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_AdjustmentDetails> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _inv_AdjustmentDetailsDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_AdjustmentDetails> GetAllAdjustmentDetailsFromAdjustmentId(string Number)
        {
            try
            {
                return _inv_AdjustmentDetailsDAO.GetAllAdjustmentDetailsFromAdjustmentId(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_AdjustmentDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _inv_AdjustmentDetailsDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
