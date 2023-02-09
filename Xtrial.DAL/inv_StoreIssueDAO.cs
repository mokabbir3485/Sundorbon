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
	public class inv_StoreIssueDAO : IDisposable
	{
		private static volatile inv_StoreIssueDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StoreIssueDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StoreIssueDAO();
			}
			return instance;
		}
		public static inv_StoreIssueDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StoreIssueDAO();
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

		public inv_StoreIssueDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_StoreIssue> Get(string? issueNo = null)
		{
			try
			{
				List<inv_StoreIssue> inv_StoreIssueLst = new List<inv_StoreIssue>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramIssueNo", issueNo, DbType.string, ParameterDirection.Input)
				};
				inv_StoreIssueLst = dbExecutor.FetchData<inv_StoreIssue>(CommandType.StoredProcedure, "wsp_inv_StoreIssue_Get", colparameters);
				return inv_StoreIssueLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_StoreIssue> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_StoreIssue> inv_StoreIssueLst = new List<inv_StoreIssue>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_StoreIssueLst = dbExecutor.FetchData<inv_StoreIssue>(CommandType.StoredProcedure, "wsp_inv_StoreIssue_GetDynamic", colparameters);
				return inv_StoreIssueLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StoreIssue> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StoreIssue> inv_StoreIssueLst = new List<inv_StoreIssue>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_StoreIssueLst = dbExecutor.FetchDataRef<inv_StoreIssue>(CommandType.StoredProcedure, "inv_StoreIssue_GetPaged", colparameters, ref rows);
				return inv_StoreIssueLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_StoreIssue _inv_StoreIssue, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[13]{
				new Parameters("@paramIssueNo", _inv_StoreIssue.IssueNo, DbType., ParameterDirection.Input),
				new Parameters("@paramIssueDate", _inv_StoreIssue.IssueDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramIssuedFromStoreId", _inv_StoreIssue.IssuedFromStoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIssuedByUserId", _inv_StoreIssue.IssuedByUserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIssueTypeId", _inv_StoreIssue.IssueTypeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramReferenceId", _inv_StoreIssue.ReferenceId, DbType., ParameterDirection.Input),
				new Parameters("@paramCounterId", _inv_StoreIssue.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramApprovalStatusId", _inv_StoreIssue.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _inv_StoreIssue.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _inv_StoreIssue.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _inv_StoreIssue.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _inv_StoreIssue.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_StoreIssue_Post", colparameters, true);
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
