using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using DbExecutor;
using XtrialEntity;

namespace XtrialDAL
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

		public List<p_PurchaseBill> Get(string? number = null)
		{
			try
			{
				List<p_PurchaseBill> p_PurchaseBillLst = new List<p_PurchaseBill>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramNumber", number, DbType.string, ParameterDirection.Input)
				};
				p_PurchaseBillLst = dbExecutor.FetchData<p_PurchaseBill>(CommandType.StoredProcedure, "wsp_p_PurchaseBill_Get", colparameters);
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
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				p_PurchaseBillLst = dbExecutor.FetchData<p_PurchaseBill>(CommandType.StoredProcedure, "wsp_p_PurchaseBill_GetDynamic", colparameters);
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
		public string Post(p_PurchaseBill _p_PurchaseBill, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[13]{
				new Parameters("@paramNumber", _p_PurchaseBill.Number, DbType., ParameterDirection.Input),
				new Parameters("@paramBillDate", _p_PurchaseBill.BillDate, DbType., ParameterDirection.Input),
				new Parameters("@paramPurchaseRequisitionNumber", _p_PurchaseBill.PurchaseRequisitionNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramManualBillNo", _p_PurchaseBill.ManualBillNo, DbType., ParameterDirection.Input),
				new Parameters("@paramSupplierId", _p_PurchaseBill.SupplierId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramApprovalStatusId", _p_PurchaseBill.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRemarks", _p_PurchaseBill.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramCounterId", _p_PurchaseBill.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _p_PurchaseBill.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _p_PurchaseBill.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _p_PurchaseBill.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _p_PurchaseBill.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_p_PurchaseBill_Post", colparameters, true);
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
