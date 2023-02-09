using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class p_PurchaseBillBLL
    {
        public p_PurchaseBillBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _p_PurchaseBillDAO = new p_PurchaseBillDAO();
        }

        public p_PurchaseBillDAO _p_PurchaseBillDAO { get; set; }

        public List<p_PurchaseBill> Get(string Number)
        {
            try
            {
                return _p_PurchaseBillDAO.GetById(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Add(p_PurchaseBill _p_PurchaseBill)
        {
            try
            {
                return _p_PurchaseBillDAO.Post(_p_PurchaseBill);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddIntoLog(p_PurchaseBill _p_PurchaseBill)
        {
            try
            {
                return _p_PurchaseBillDAO.PostIntoLog(_p_PurchaseBill);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DetailAdd(p_PurchaseBillDetails p_PurchaseBillDetails)
        {
            try
            {
                return _p_PurchaseBillDAO.DetailAdd(p_PurchaseBillDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DetailLogAdd(p_PurchaseBillDetails p_PurchaseBillDetails,string transactiontype)
        {
            try
            {
                return _p_PurchaseBillDAO.DetailLogAdd(p_PurchaseBillDetails, transactiontype);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<p_PurchaseBill> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _p_PurchaseBillDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<inv_StockAudit> GetAll()
        //{
        //    try
        //    {
        //        return _p_PurchaseBillDAO.GetALL();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<p_PurchaseBill> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _p_PurchaseBillDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<p_PurchaseBillDetails> p_PurchaseBillDetails_GetBy_Number(string number)
        {
            try
            {
                return _p_PurchaseBillDAO.p_PurchaseBillDetails_GetBy_Number(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<xrpt_p_PurchaseBillDetail> p_PurchaseBillDetails_GetBy_Report(string number)
        {
            try
            {
                return _p_PurchaseBillDAO.p_PurchaseBillDetails_GetBy_Report(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<p_PurchaseBill> GetAll()
        {
            try
            {
                return _p_PurchaseBillDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<p_PurchaseBill> p_PurchaseBill_GetByIssue(DateTime ? fromDate=null,DateTime ? toDate =null)
        {
            try
            {
                return _p_PurchaseBillDAO.p_PurchaseBill_GetByIssue(fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        


    }
}
