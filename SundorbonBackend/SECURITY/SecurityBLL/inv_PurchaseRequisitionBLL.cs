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
    public class inv_PurchaseRequisitionBLL
    {
        public inv_PurchaseRequisitionBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _inv_PurchaseRequisitionDAO = new inv_PurchaseRequisitionDAO();
        }

        public inv_PurchaseRequisitionDAO _inv_PurchaseRequisitionDAO { get; set; }

        public string Add(inv_PurchaseRequisition _inv_PurchaseRequisition)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.Post(_inv_PurchaseRequisition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Add(inv_Ammendment _Ammendment)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.AddAmmendment(_Ammendment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddAmmendmentDetail(inv_AmmendmentDetails _AmmendmentDetails)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.AddAmmendmentDetail(_AmmendmentDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_PurchaseRequisition> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_Ammendment> AmendmentGetByApprovalGivenOnId(int ApprovalGivenOnId)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.AmendmentGetByApprovalGivenOnId(ApprovalGivenOnId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_AmmendmentDetails> GetByAmendIdReport(int Id)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetByAmendIdReport(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<inv_PurchaseRequisition> GetAll()
        //{
        //    try
        //    {
        //        return _inv_PurchaseRequisitionDAO.GetAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<inv_PurchaseRequisition> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_PR_Amend_Report> GetAllAmendAndRequisition(string Number, DateTime? FromDate, DateTime? ToDate)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetAllAmendAndRequisition(Number, FromDate, ToDate);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public List<inv_PurchaseRequisition> GetAllNumber()
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetAllNumber();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public List<inv_PurchaseRequisitionDetails> GetDetailsPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
    string sortOrder, ref int rows)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetDetailsPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Counter> GetAllCounter()
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetAllCounter();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_PurchaseRequisitionDetails> GetByPurchaseRequisitionNumber(string number)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetByPurchaseRequisitionNumber(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_PurchaseRequisitionDetails> GetByPurchaseRequisitionReport(string number)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetByPurchaseRequisitionReport(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<xrpt_inv_PurchaseRequisition> GetAll()
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_PurchaseRequisitionDetails> GetByRequisitionNumber(string number)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetByRequisitionNumber(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_PurchaseRequisition> GetByNumber(string number)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.GetByNumber(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddIntoReuisitionLog(inv_PurchaseRequisition _inv_PurchaseRequisition)
        {
            try
            {
                return _inv_PurchaseRequisitionDAO.PostIntoRequistionLog(_inv_PurchaseRequisition);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
