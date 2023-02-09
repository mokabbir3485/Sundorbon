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
	public class ws_AdjustmentDetailsDAO : IDisposable
	{
		private static volatile ws_AdjustmentDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static ws_AdjustmentDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_AdjustmentDetailsDAO();
			}
			return instance;
		}
		public static ws_AdjustmentDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_AdjustmentDetailsDAO();
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

		public ws_AdjustmentDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_AdjustmentDetails> Get(Int32? id = null)
		{
			try
			{
				List<ws_AdjustmentDetails> ws_AdjustmentDetailsLst = new List<ws_AdjustmentDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ws_AdjustmentDetailsLst = dbExecutor.FetchData<ws_AdjustmentDetails>(CommandType.StoredProcedure, "wsp_ws_AdjustmentDetails_Get", colparameters);
				return ws_AdjustmentDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_AdjustmentDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_AdjustmentDetails> ws_AdjustmentDetailsLst = new List<ws_AdjustmentDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_AdjustmentDetailsLst = dbExecutor.FetchData<ws_AdjustmentDetails>(CommandType.StoredProcedure, "wsp_ws_AdjustmentDetails_GetDynamic", colparameters);
				return ws_AdjustmentDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_AdjustmentDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_AdjustmentDetails> ws_AdjustmentDetailsLst = new List<ws_AdjustmentDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_AdjustmentDetailsLst = dbExecutor.FetchDataRef<ws_AdjustmentDetails>(CommandType.StoredProcedure, "ws_AdjustmentDetails_GetPaged", colparameters, ref rows);
				return ws_AdjustmentDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_AdjustmentDetails _ws_AdjustmentDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[9]{
				new Parameters("@paramId", _ws_AdjustmentDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramAdjustmentNumber", _ws_AdjustmentDetails.AdjustmentNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramRackId", _ws_AdjustmentDetails.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramItemId", _ws_AdjustmentDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIsIncreased", _ws_AdjustmentDetails.IsIncreased, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramAdjustedQty", _ws_AdjustmentDetails.AdjustedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramAdjstedUnitPrice", _ws_AdjustmentDetails.AdjstedUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramRemarks", _ws_AdjustmentDetails.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_AdjustmentDetails_Post", colparameters, true);
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
