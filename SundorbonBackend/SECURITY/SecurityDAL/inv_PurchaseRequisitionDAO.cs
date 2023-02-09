using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using DbExecutor;
using Sundorbon.Backend.SECURITY.SecurityEntity;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
    public class inv_PurchaseRequisitionDAO : IDisposable
    {
        private static volatile inv_PurchaseRequisitionDAO instance;
        private static readonly object lockObj = new object();
        public static inv_PurchaseRequisitionDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new inv_PurchaseRequisitionDAO();
            }
            return instance;
        }
        public static inv_PurchaseRequisitionDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new inv_PurchaseRequisitionDAO();
                        }
                    }
                }
                return instance;
            }
        }

        public void Dispose()
        {
            ((IDisposable)GetInstanceThreadSafe).Dispose();
        }

        DBExecutor dbExecutor;

        public inv_PurchaseRequisitionDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public List<xrpt_inv_PurchaseRequisition> Get()
        {
            try
            {
                List<xrpt_inv_PurchaseRequisition> inv_PurchaseRequisitionLst = new List<xrpt_inv_PurchaseRequisition>();

                inv_PurchaseRequisitionLst = dbExecutor.FetchData<xrpt_inv_PurchaseRequisition>(CommandType.StoredProcedure, "inv_PurchaseRequisition_GetAll");
                return inv_PurchaseRequisitionLst;
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
                List<inv_PurchaseRequisition> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisition>();
                Parameters[] colparameters = new Parameters[2]{
                new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
                new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
                };
                inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PurchaseRequisition>(CommandType.StoredProcedure, "inv_PurchaseRequisition_GetDynamic", colparameters);
                return inv_PurchaseRequisitionLst;
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
                List<inv_Ammendment> inv_AmmendmentList = new List<inv_Ammendment>();
                Parameters[] colparameters = new Parameters[1]{
                new Parameters("@ApprovalGivenOnId", ApprovalGivenOnId, DbType.Int32, ParameterDirection.Input),
                };
                inv_AmmendmentList = dbExecutor.FetchData<inv_Ammendment>(CommandType.StoredProcedure, "GetAll_inv_Amendment_Approve", colparameters);
                return inv_AmmendmentList;
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
                List<inv_AmmendmentDetails> inv_AmmendmentList = new List<inv_AmmendmentDetails>();
                Parameters[] colparameters = new Parameters[1]{
                new Parameters("@Number", Id, DbType.Int32, ParameterDirection.Input),
                };
                inv_AmmendmentList = dbExecutor.FetchData<inv_AmmendmentDetails>(CommandType.StoredProcedure, "inv_AmendmentDetails_Report", colparameters);
                return inv_AmmendmentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_PurchaseRequisition> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
        {
            try
            {
                List<inv_PurchaseRequisition> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisition>();
                Parameters[] colparameters = new Parameters[5]{
                new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
                new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
                new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
                new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
                new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
                };
                inv_PurchaseRequisitionLst = dbExecutor.FetchDataRef<inv_PurchaseRequisition>(CommandType.StoredProcedure, "inv_PurchaseRequisition_GetPaged", colparameters, ref rows);
                return inv_PurchaseRequisitionLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_PurchaseRequisitionDetails> GetDetailsPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
        {
            try
            {
                List<inv_PurchaseRequisitionDetails> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisitionDetails>();
                Parameters[] colparameters = new Parameters[5]{
                new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
                new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
                new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
                new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
                new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
                };
                inv_PurchaseRequisitionLst = dbExecutor.FetchDataRef<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "inv_PurchaseRequisitionDetails_GetPaged_with_PurchaseRequisition", colparameters, ref rows);
                return inv_PurchaseRequisitionLst;
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
                List<ad_Counter> ad_StoreLst = new List<ad_Counter>();

                ad_StoreLst = dbExecutor.FetchData<ad_Counter>(CommandType.StoredProcedure, "ad_Counter_GetAll");
                return ad_StoreLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_PurchaseRequisitionDetails> GetByPurchaseRequisitionNumber(string Number)
        {
            try
            {


                List<inv_PurchaseRequisitionDetails> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisitionDetails>();
                Parameters[] colparameters = new Parameters[1]{
                new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

                };
                inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "GetByPurchaseRequisitionNumber", colparameters);
                return inv_PurchaseRequisitionLst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<inv_PurchaseRequisitionDetails> GetByPurchaseRequisitionReport(string Number)
        {
            try
            {


                List<inv_PurchaseRequisitionDetails> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisitionDetails>();
                Parameters[] colparameters = new Parameters[1]{
                new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

                };
                inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "xrpt_GetByPurchaseRequisitionNumber", colparameters);
                return inv_PurchaseRequisitionLst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public string Post(inv_PurchaseRequisition _inv_PurchaseRequisition)
        {
            string ret = string.Empty;
            try
            {
                Parameters[] colparameters = new Parameters[11]{

                new Parameters("@Number", _inv_PurchaseRequisition.Number, DbType.String, ParameterDirection.Input),
                new Parameters("@PurposeId", _inv_PurchaseRequisition.PurposeId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@RequisitionDate", _inv_PurchaseRequisition.RequisitionDate, DbType.String, ParameterDirection.Input),
                new Parameters("@CounterId", _inv_PurchaseRequisition.CounterId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@RequestedByEmployeeId", _inv_PurchaseRequisition.RequestedByEmployeeId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@ApprovalStatusId", _inv_PurchaseRequisition.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@CreatorId", _inv_PurchaseRequisition.CreatorId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@CreateDate", _inv_PurchaseRequisition.CreateDate, DbType.DateTime, ParameterDirection.Input),
                new Parameters("@UpdatorId", _inv_PurchaseRequisition.UpdatorId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@UpdateDate", _inv_PurchaseRequisition.UpdateDate, DbType.DateTime, ParameterDirection.Input),
                new Parameters("@TransactiontionType", _inv_PurchaseRequisition.TransactiontionType, DbType.String, ParameterDirection.Input),

                };

                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "inv_PurchaseRequisition_Post", colparameters, true);
                dbExecutor.ManageTransaction(TransactionType.Commit);
            }
            catch (DBConcurrencyException except)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw except;
            }
            catch (Exception ex)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw ex;
            }
            return ret;


        }


        public int AddAmmendment(inv_Ammendment _Ammendment)
        {
            int ret = 0;
            try
            {
                Parameters[] colparameters = new Parameters[6]{

                new Parameters("@Id", _Ammendment.Id, DbType.String, ParameterDirection.Input),
                new Parameters("@AmendDate", _Ammendment.AmendDate, DbType.DateTime, ParameterDirection.Input),
                new Parameters("@ApprovalGivenOnId", _Ammendment.ApprovalGivenOnId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@ReferenceTransactionNumber", _Ammendment.ReferenceTransactionNumber, DbType.String, ParameterDirection.Input),
                new Parameters("@AmendmentByEmployeeId", _Ammendment.AmendmentByEmployeeId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@TransactionType", _Ammendment.TransactionType, DbType.String, ParameterDirection.Input),

                };

                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "inv_Amendment_Post", colparameters, true);
                dbExecutor.ManageTransaction(TransactionType.Commit);
            }
            catch (DBConcurrencyException except)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw except;
            }
            catch (Exception ex)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw ex;
            }
            return ret;


        }

        public int AddAmmendmentDetail(inv_AmmendmentDetails _inv_AmmendmentDetails)
        {
            int ret = 0;
            try
            {
                Parameters[] colparameters = new Parameters[9]{

                new Parameters("@Id", _inv_AmmendmentDetails.Id, DbType.Int32, ParameterDirection.Input),
                new Parameters("@AmmendmentId", _inv_AmmendmentDetails.AmmendmentId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@ItemId", _inv_AmmendmentDetails.ItemId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@AmendedQuantity", _inv_AmmendmentDetails.AmendedQuantity, DbType.Decimal, ParameterDirection.Input),
                new Parameters("@AmendedPrice", _inv_AmmendmentDetails.AmendedPrice, DbType.Decimal, ParameterDirection.Input),
                new Parameters("@Remarks", _inv_AmmendmentDetails.Remarks, DbType.String, ParameterDirection.Input),
                new Parameters("@VatId", _inv_AmmendmentDetails.Vat, DbType.Decimal, ParameterDirection.Input),
                new Parameters("@AIT", _inv_AmmendmentDetails.AIT, DbType.Decimal, ParameterDirection.Input),
                new Parameters("@SD", _inv_AmmendmentDetails.SD, DbType.Decimal, ParameterDirection.Input),

                };

                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "inv_AmendmentDetails_Post", colparameters, true);
                dbExecutor.ManageTransaction(TransactionType.Commit);
            }
            catch (DBConcurrencyException except)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw except;
            }
            catch (Exception ex)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw ex;
            }
            return ret;


        }
        public List<inv_PurchaseRequisitionDetails> GetByRequisitionNumber(string Number)
        {
            try
            {


                List<inv_PurchaseRequisitionDetails> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisitionDetails>();
                Parameters[] colparameters = new Parameters[1]{
                new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

                };
                inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "inv_PurchaseRequisitionDetails_GetByRequisitionNumber", colparameters);
                return inv_PurchaseRequisitionLst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_PurchaseRequisition> GetByNumber(string Number)
        {
            try
            {
                List<inv_PurchaseRequisition> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisition>();
                Parameters[] colparameters = new Parameters[1]{
                    new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),
                };
                inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PurchaseRequisition>(CommandType.StoredProcedure, "inv_PurchaseRequisition_GetByNumber", colparameters);
                return inv_PurchaseRequisitionLst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string PostIntoRequistionLog(inv_PurchaseRequisition _inv_PurchaseRequisition)
        {
            string ret = string.Empty;
            try
            {
                Parameters[] colparameters = new Parameters[11]{

                new Parameters("@Number", _inv_PurchaseRequisition.Number, DbType.String, ParameterDirection.Input),
                new Parameters("@PurposeId", _inv_PurchaseRequisition.PurposeId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@RequisitionDate", _inv_PurchaseRequisition.RequisitionDate, DbType.String, ParameterDirection.Input),
                new Parameters("@CounterId", _inv_PurchaseRequisition.CounterId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@RequestedByEmployeeId", _inv_PurchaseRequisition.RequestedByEmployeeId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@ApprovalStatusId", _inv_PurchaseRequisition.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@CreatorId", _inv_PurchaseRequisition.CreatorId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@CreateDate", _inv_PurchaseRequisition.CreateDate, DbType.DateTime, ParameterDirection.Input),
                new Parameters("@UpdatorId", _inv_PurchaseRequisition.UpdatorId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@UpdateDate", _inv_PurchaseRequisition.UpdateDate, DbType.DateTime, ParameterDirection.Input),
                new Parameters("@TransactiontionType", _inv_PurchaseRequisition.TransactiontionType, DbType.String, ParameterDirection.Input),

                };

                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "inv_PurchaseRequisition_Log_Post", colparameters, true);
                dbExecutor.ManageTransaction(TransactionType.Commit);
            }
            catch (DBConcurrencyException except)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw except;
            }
            catch (Exception ex)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw ex;
            }
            return ret;


        }
        public List<inv_PR_Amend_Report> GetAllAmendAndRequisition(string Number, DateTime? FromDate, DateTime? ToDate)
        {
            try
            {
                List<inv_PR_Amend_Report> inv_PurchaseRequisitionLst = new List<inv_PR_Amend_Report>();
                Parameters[] colparameters = new Parameters[3]{
                    new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),
                    new Parameters("@Fromdate", FromDate, DbType.DateTime, ParameterDirection.Input),
                    new Parameters("@Todate", ToDate, DbType.DateTime, ParameterDirection.Input),
                };
                inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PR_Amend_Report>(CommandType.StoredProcedure, "inv_pr_amend", colparameters);
                return inv_PurchaseRequisitionLst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<inv_PurchaseRequisition> GetAllNumber()
        {
            try
            {
                List<inv_PurchaseRequisition> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisition>();
                inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PurchaseRequisition>(CommandType.StoredProcedure, "inv_PurchaseRequisition_GetAll_All_Status");
                return inv_PurchaseRequisitionLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
