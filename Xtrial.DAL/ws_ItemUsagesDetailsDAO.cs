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
	public class ws_ItemUsagesDetailsDAO : IDisposable
	{
		private static volatile ws_ItemUsagesDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static ws_ItemUsagesDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_ItemUsagesDetailsDAO();
			}
			return instance;
		}
		public static ws_ItemUsagesDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_ItemUsagesDetailsDAO();
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

		public ws_ItemUsagesDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_ItemUsagesDetails> Get(Int32? id = null)
		{
			try
			{
				List<ws_ItemUsagesDetails> ws_ItemUsagesDetailsLst = new List<ws_ItemUsagesDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ws_ItemUsagesDetailsLst = dbExecutor.FetchData<ws_ItemUsagesDetails>(CommandType.StoredProcedure, "wsp_ws_ItemUsagesDetails_Get", colparameters);
				return ws_ItemUsagesDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_ItemUsagesDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_ItemUsagesDetails> ws_ItemUsagesDetailsLst = new List<ws_ItemUsagesDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_ItemUsagesDetailsLst = dbExecutor.FetchData<ws_ItemUsagesDetails>(CommandType.StoredProcedure, "wsp_ws_ItemUsagesDetails_GetDynamic", colparameters);
				return ws_ItemUsagesDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_ItemUsagesDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_ItemUsagesDetails> ws_ItemUsagesDetailsLst = new List<ws_ItemUsagesDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_ItemUsagesDetailsLst = dbExecutor.FetchDataRef<ws_ItemUsagesDetails>(CommandType.StoredProcedure, "ws_ItemUsagesDetails_GetPaged", colparameters, ref rows);
				return ws_ItemUsagesDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_ItemUsagesDetails _ws_ItemUsagesDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramId", _ws_ItemUsagesDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUsagesNumber", _ws_ItemUsagesDetails.UsagesNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramStoreId", _ws_ItemUsagesDetails.StoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRackId", _ws_ItemUsagesDetails.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramItemId", _ws_ItemUsagesDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUsageQty", _ws_ItemUsagesDetails.UsageQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramUsagedPriced", _ws_ItemUsagesDetails.UsagedPriced, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramIsVoid", _ws_ItemUsagesDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramRemarks", _ws_ItemUsagesDetails.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_ItemUsagesDetails_Post", colparameters, true);
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
