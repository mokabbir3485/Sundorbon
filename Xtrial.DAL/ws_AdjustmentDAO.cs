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
	public class ws_AdjustmentDAO : IDisposable
	{
		private static volatile ws_AdjustmentDAO instance;
		private static readonly object lockObj = new object();
		public static ws_AdjustmentDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_AdjustmentDAO();
			}
			return instance;
		}
		public static ws_AdjustmentDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_AdjustmentDAO();
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

		public ws_AdjustmentDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_Adjustment> Get(string? number = null)
		{
			try
			{
				List<ws_Adjustment> ws_AdjustmentLst = new List<ws_Adjustment>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramNumber", number, DbType.string, ParameterDirection.Input)
				};
				ws_AdjustmentLst = dbExecutor.FetchData<ws_Adjustment>(CommandType.StoredProcedure, "wsp_ws_Adjustment_Get", colparameters);
				return ws_AdjustmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_Adjustment> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_Adjustment> ws_AdjustmentLst = new List<ws_Adjustment>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_AdjustmentLst = dbExecutor.FetchData<ws_Adjustment>(CommandType.StoredProcedure, "wsp_ws_Adjustment_GetDynamic", colparameters);
				return ws_AdjustmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_Adjustment> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_Adjustment> ws_AdjustmentLst = new List<ws_Adjustment>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_AdjustmentLst = dbExecutor.FetchDataRef<ws_Adjustment>(CommandType.StoredProcedure, "ws_Adjustment_GetPaged", colparameters, ref rows);
				return ws_AdjustmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_Adjustment _ws_Adjustment, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramNumber", _ws_Adjustment.Number, DbType., ParameterDirection.Input),
				new Parameters("@paramAdjustmentDate", _ws_Adjustment.AdjustmentDate, DbType., ParameterDirection.Input),
				new Parameters("@paramAdjustedByUserId", _ws_Adjustment.AdjustedByUserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramAdjustedReason", _ws_Adjustment.AdjustedReason, DbType., ParameterDirection.Input),
				new Parameters("@paramCounterId", _ws_Adjustment.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ws_Adjustment.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _ws_Adjustment.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ws_Adjustment.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ws_Adjustment.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_Adjustment_Post", colparameters, true);
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
