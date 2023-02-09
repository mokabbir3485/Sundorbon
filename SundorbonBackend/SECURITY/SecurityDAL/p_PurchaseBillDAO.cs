using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using DbExecutor;
using XtrialEntity;
using Sundorbon.Backend.SECURITY.SecurityEntity;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
	public class p_PurchaseBillDAO : IDisposable
	{
		private static volatile p_PurchaseBillDAO instance;
		private static readonly object lockObj = new object();
		public static p_PurchaseBillDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new p_PurchaseBillDAO();
			}
			return instance;
		}
		public static p_PurchaseBillDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new p_PurchaseBillDAO();
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

		public p_PurchaseBillDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<p_PurchaseBill> GetById(String number)
		{
			try
			{
				List<p_PurchaseBill> p_PurchaseBillLst = new List<p_PurchaseBill>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", number, DbType.String, ParameterDirection.Input)
				};
				p_PurchaseBillLst = dbExecutor.FetchData<p_PurchaseBill>(CommandType.StoredProcedure, "p_PurchaseBill_GetByNumber", colparameters);
				return p_PurchaseBillLst;
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
				List<p_PurchaseBill> p_PurchaseBillLst = new List<p_PurchaseBill>();
			
				p_PurchaseBillLst = dbExecutor.FetchData<p_PurchaseBill>(CommandType.StoredProcedure, "p_GetAllPurchaseBillWithoutRecived");
				return p_PurchaseBillLst;
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
				List<p_PurchaseBill> p_PurchaseBillLst = new List<p_PurchaseBill>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@fromDate", fromDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@toDate", toDate, DbType.DateTime, ParameterDirection.Input)
				};

				p_PurchaseBillLst = dbExecutor.FetchData<p_PurchaseBill>(CommandType.StoredProcedure, "p_PurchaseBill_GetByIssue", colparameters);
				return p_PurchaseBillLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		

		public List<p_PurchaseBill> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<p_PurchaseBill> p_PurchaseBillLst = new List<p_PurchaseBill>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				p_PurchaseBillLst = dbExecutor.FetchData<p_PurchaseBill>(CommandType.StoredProcedure, "p_PurchaseBill_GetDynamic", colparameters);
				return p_PurchaseBillLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<p_PurchaseBill> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<p_PurchaseBill> p_PurchaseBillLst = new List<p_PurchaseBill>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				p_PurchaseBillLst = dbExecutor.FetchDataRef<p_PurchaseBill>(CommandType.StoredProcedure, "p_PurchaseBill_GetPaged", colparameters, ref rows);
				return p_PurchaseBillLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<p_PurchaseBillDetails> p_PurchaseBillDetails_GetBy_Number(string Number)
		{
			try
			{


				List<p_PurchaseBillDetails> p_PurchaseBillDetailsList = new List<p_PurchaseBillDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

				};
				p_PurchaseBillDetailsList = dbExecutor.FetchData<p_PurchaseBillDetails>(CommandType.StoredProcedure, "p_PurchaseBillDetails_GetBy_Number", colparameters);
				return p_PurchaseBillDetailsList;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<xrpt_p_PurchaseBillDetail> p_PurchaseBillDetails_GetBy_Report(string Number)
		{
			try
			{


				List<xrpt_p_PurchaseBillDetail> p_PurchaseBillDetailsList = new List<xrpt_p_PurchaseBillDetail>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

				};
				p_PurchaseBillDetailsList = dbExecutor.FetchData<xrpt_p_PurchaseBillDetail>(CommandType.StoredProcedure, "xrpt_p_PurchaseBillDetails_GetBy_Number", colparameters);
				return p_PurchaseBillDetailsList;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(p_PurchaseBill _p_PurchaseBill)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[11]{
				new Parameters("@Number", _p_PurchaseBill.Number, DbType.String, ParameterDirection.Input),
				new Parameters("@BillDate", _p_PurchaseBill.BillDate, DbType.String, ParameterDirection.Input),
				new Parameters("@PurchaseRequisitionNumber", _p_PurchaseBill.PurchaseRequisitionNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ManualBillNo", _p_PurchaseBill.ManualBillNo, DbType.String, ParameterDirection.Input),
				new Parameters("@SupplierId", _p_PurchaseBill.SupplierId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ApprovalStatusId", _p_PurchaseBill.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Remarks", _p_PurchaseBill.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@CounterId", _p_PurchaseBill.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _p_PurchaseBill.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _p_PurchaseBill.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@TransactionType", _p_PurchaseBill.TransactionType, DbType.String, ParameterDirection.Input),
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "p_PurchaseBill_Post", colparameters, true);
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
		public string PostIntoLog(p_PurchaseBill _p_PurchaseBill)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[11]{
				new Parameters("@Number", _p_PurchaseBill.Number, DbType.String, ParameterDirection.Input),
				new Parameters("@BillDate", _p_PurchaseBill.BillDate, DbType.String, ParameterDirection.Input),
				new Parameters("@PurchaseRequisitionNumber", _p_PurchaseBill.PurchaseRequisitionNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ManualBillNo", _p_PurchaseBill.ManualBillNo, DbType.String, ParameterDirection.Input),
				new Parameters("@SupplierId", _p_PurchaseBill.SupplierId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ApprovalStatusId", _p_PurchaseBill.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Remarks", _p_PurchaseBill.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@CounterId", _p_PurchaseBill.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _p_PurchaseBill.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _p_PurchaseBill.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@TransactionType", _p_PurchaseBill.TransactionType, DbType.String, ParameterDirection.Input),
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "p_PurchaseBill_Log_Post", colparameters, true);
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

		//DetailAdd

		public int DetailAdd(p_PurchaseBillDetails p_PurchaseBillDetails)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[11]{
				new Parameters("@Id", p_PurchaseBillDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@PuchaseBillNumber", p_PurchaseBillDetails.PuchaseBillNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ItemId", p_PurchaseBillDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Qty", p_PurchaseBillDetails.Qty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@UnitPrice", p_PurchaseBillDetails.UnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@Amount", p_PurchaseBillDetails.Amount, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@Discount", p_PurchaseBillDetails.Discount, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@AfterDiscount", p_PurchaseBillDetails.AfterDiscount, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@AIT", p_PurchaseBillDetails.AIT, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@SD", p_PurchaseBillDetails.SD, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@VAT", p_PurchaseBillDetails.VAT, DbType.Decimal, ParameterDirection.Input),
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "p_PurchaseBillDetails_Post", colparameters, true);
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
		public int DetailLogAdd(p_PurchaseBillDetails p_PurchaseBillDetails, string transactiontype)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[12]{
				new Parameters("@Id", p_PurchaseBillDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@PuchaseBillNumber", p_PurchaseBillDetails.PuchaseBillNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ItemId", p_PurchaseBillDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Qty", p_PurchaseBillDetails.Qty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@UnitPrice", p_PurchaseBillDetails.UnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@Amount", p_PurchaseBillDetails.Amount, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@Discount", p_PurchaseBillDetails.Discount, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@AfterDiscount", p_PurchaseBillDetails.AfterDiscount, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@AIT", p_PurchaseBillDetails.AIT, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@SD", p_PurchaseBillDetails.SD, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@VAT", p_PurchaseBillDetails.VAT, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@TransactionType", transactiontype, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "p_PurchaseBillDetails_Log_Post", colparameters, true);
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
	}
}
