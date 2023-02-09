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

namespace XtrialDAL
{
	public class ad_TransactionApprovalDAO : IDisposable
	{
		private static volatile ad_TransactionApprovalDAO instance;
		private static readonly object lockObj = new object();
		public static ad_TransactionApprovalDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_TransactionApprovalDAO();
			}
			return instance;
		}
		public static ad_TransactionApprovalDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_TransactionApprovalDAO();
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

		public ad_TransactionApprovalDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_TransactionApproval> Get(Int32? id = null)
		{
			try
			{
				List<ad_TransactionApproval> ad_TransactionApprovalLst = new List<ad_TransactionApproval>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_TransactionApprovalLst = dbExecutor.FetchData<ad_TransactionApproval>(CommandType.StoredProcedure, "ad_TransactionApproval_Get", colparameters);
				return ad_TransactionApprovalLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_TransactionApproval> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_TransactionApproval> ad_TransactionApprovalLst = new List<ad_TransactionApproval>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_TransactionApprovalLst = dbExecutor.FetchData<ad_TransactionApproval>(CommandType.StoredProcedure, "ad_TransactionApproval_GetDynamic", colparameters);
				return ad_TransactionApprovalLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_TransactionApproval> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_TransactionApproval> ad_TransactionApprovalLst = new List<ad_TransactionApproval>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_TransactionApprovalLst = dbExecutor.FetchDataRef<ad_TransactionApproval>(CommandType.StoredProcedure, "ad_TransactionApproval_GetPaged", colparameters, ref rows);
				return ad_TransactionApprovalLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_TransactionApproval _ad_TransactionApproval)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[9]{
				new Parameters("@Id", _ad_TransactionApproval.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@DepartmentId", _ad_TransactionApproval.DepartmentId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ApprovalDate", _ad_TransactionApproval.ApprovalDate, DbType.String, ParameterDirection.Input),
				new Parameters("@ApprovalStatusId", _ad_TransactionApproval.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ApprovalGivenOnId", _ad_TransactionApproval.ApprovalGivenOnId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ReferenceTransactionNumber", _ad_TransactionApproval.ReferenceTransactionNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@Remarks", _ad_TransactionApproval.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_TransactionApproval.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_TransactionApproval.UpdatorId, DbType.Int32, ParameterDirection.Input)
				
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_TransactionApproval_Post", colparameters, true);
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
		public List<TransactionApproveTablename> GetNumber(string TableName,DateTime? FromDate, DateTime? ToDate)
		{
			try
			{
				List<TransactionApproveTablename> ad_TransactionApprovalLst = new List<TransactionApproveTablename>();
				Parameters[] colparameters = new Parameters[3]{
				new Parameters("@Tablename", TableName, DbType.String, ParameterDirection.Input),
				new Parameters("@Fromdate", FromDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@Todate", ToDate, DbType.DateTime, ParameterDirection.Input)
				};
				ad_TransactionApprovalLst = dbExecutor.FetchData<TransactionApproveTablename>(CommandType.StoredProcedure, "GetPendingPrPbByTransactionAproveTablename", colparameters);
				return ad_TransactionApprovalLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
