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
	public class ws_IssueItemDetailsDAO : IDisposable
	{
		private static volatile ws_IssueItemDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static ws_IssueItemDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_IssueItemDetailsDAO();
			}
			return instance;
		}
		public static ws_IssueItemDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_IssueItemDetailsDAO();
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

		public ws_IssueItemDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_IssueItemDetails> Get(Int32? id = null)
		{
			try
			{
				List<ws_IssueItemDetails> ws_IssueItemDetailsLst = new List<ws_IssueItemDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ws_IssueItemDetailsLst = dbExecutor.FetchData<ws_IssueItemDetails>(CommandType.StoredProcedure, "wsp_ws_IssueItemDetails_Get", colparameters);
				return ws_IssueItemDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_IssueItemDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_IssueItemDetails> ws_IssueItemDetailsLst = new List<ws_IssueItemDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_IssueItemDetailsLst = dbExecutor.FetchData<ws_IssueItemDetails>(CommandType.StoredProcedure, "wsp_ws_IssueItemDetails_GetDynamic", colparameters);
				return ws_IssueItemDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_IssueItemDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_IssueItemDetails> ws_IssueItemDetailsLst = new List<ws_IssueItemDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_IssueItemDetailsLst = dbExecutor.FetchDataRef<ws_IssueItemDetails>(CommandType.StoredProcedure, "ws_IssueItemDetails_GetPaged", colparameters, ref rows);
				return ws_IssueItemDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_IssueItemDetails _ws_IssueItemDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[9]{
				new Parameters("@paramId", _ws_IssueItemDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIssueNumber", _ws_IssueItemDetails.IssueNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramStoreId", _ws_IssueItemDetails.StoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRackId", _ws_IssueItemDetails.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIssuedQty", _ws_IssueItemDetails.IssuedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramIssuedPrice", _ws_IssueItemDetails.IssuedPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramIsVoid", _ws_IssueItemDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramRemarks", _ws_IssueItemDetails.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_IssueItemDetails_Post", colparameters, true);
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
