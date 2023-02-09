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
	public class inv_StoreIssueDetailsDAO : IDisposable
	{
		private static volatile inv_StoreIssueDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StoreIssueDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StoreIssueDetailsDAO();
			}
			return instance;
		}
		public static inv_StoreIssueDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StoreIssueDetailsDAO();
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

		public inv_StoreIssueDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_StoreIssueDetails> Get(Int32? id = null)
		{
			try
			{
				List<inv_StoreIssueDetails> inv_StoreIssueDetailsLst = new List<inv_StoreIssueDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_StoreIssueDetailsLst = dbExecutor.FetchData<inv_StoreIssueDetails>(CommandType.StoredProcedure, "wsp_inv_StoreIssueDetails_Get", colparameters);
				return inv_StoreIssueDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_StoreIssueDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_StoreIssueDetails> inv_StoreIssueDetailsLst = new List<inv_StoreIssueDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_StoreIssueDetailsLst = dbExecutor.FetchData<inv_StoreIssueDetails>(CommandType.StoredProcedure, "wsp_inv_StoreIssueDetails_GetDynamic", colparameters);
				return inv_StoreIssueDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StoreIssueDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StoreIssueDetails> inv_StoreIssueDetailsLst = new List<inv_StoreIssueDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_StoreIssueDetailsLst = dbExecutor.FetchDataRef<inv_StoreIssueDetails>(CommandType.StoredProcedure, "inv_StoreIssueDetails_GetPaged", colparameters, ref rows);
				return inv_StoreIssueDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_StoreIssueDetails _inv_StoreIssueDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@paramId", _inv_StoreIssueDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIssueNumber", _inv_StoreIssueDetails.IssueNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramRackId", _inv_StoreIssueDetails.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramItemId", _inv_StoreIssueDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIssuedQty", _inv_StoreIssueDetails.IssuedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramIssuedPrice", _inv_StoreIssueDetails.IssuedPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramRemarks", _inv_StoreIssueDetails.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_StoreIssueDetails_Post", colparameters, true);
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
