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
	public class ws_StoreItemReceiveDetailsDAO : IDisposable
	{
		private static volatile ws_StoreItemReceiveDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static ws_StoreItemReceiveDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_StoreItemReceiveDetailsDAO();
			}
			return instance;
		}
		public static ws_StoreItemReceiveDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_StoreItemReceiveDetailsDAO();
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

		public ws_StoreItemReceiveDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_StoreItemReceiveDetails> Get(Int32? id = null)
		{
			try
			{
				List<ws_StoreItemReceiveDetails> ws_StoreItemReceiveDetailsLst = new List<ws_StoreItemReceiveDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ws_StoreItemReceiveDetailsLst = dbExecutor.FetchData<ws_StoreItemReceiveDetails>(CommandType.StoredProcedure, "wsp_ws_StoreItemReceiveDetails_Get", colparameters);
				return ws_StoreItemReceiveDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_StoreItemReceiveDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_StoreItemReceiveDetails> ws_StoreItemReceiveDetailsLst = new List<ws_StoreItemReceiveDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_StoreItemReceiveDetailsLst = dbExecutor.FetchData<ws_StoreItemReceiveDetails>(CommandType.StoredProcedure, "wsp_ws_StoreItemReceiveDetails_GetDynamic", colparameters);
				return ws_StoreItemReceiveDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_StoreItemReceiveDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_StoreItemReceiveDetails> ws_StoreItemReceiveDetailsLst = new List<ws_StoreItemReceiveDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_StoreItemReceiveDetailsLst = dbExecutor.FetchDataRef<ws_StoreItemReceiveDetails>(CommandType.StoredProcedure, "ws_StoreItemReceiveDetails_GetPaged", colparameters, ref rows);
				return ws_StoreItemReceiveDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_StoreItemReceiveDetails _ws_StoreItemReceiveDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramId", _ws_StoreItemReceiveDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramStoreReceiveNumber", _ws_StoreItemReceiveDetails.StoreReceiveNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramStoreId", _ws_StoreItemReceiveDetails.StoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRackId", _ws_StoreItemReceiveDetails.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramItemId", _ws_StoreItemReceiveDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramReceiveQty", _ws_StoreItemReceiveDetails.ReceiveQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramReceivedPrice", _ws_StoreItemReceiveDetails.ReceivedPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramIsVoid", _ws_StoreItemReceiveDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramRemarks", _ws_StoreItemReceiveDetails.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_StoreItemReceiveDetails_Post", colparameters, true);
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
