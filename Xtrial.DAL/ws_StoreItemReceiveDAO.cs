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
	public class ws_StoreItemReceiveDAO : IDisposable
	{
		private static volatile ws_StoreItemReceiveDAO instance;
		private static readonly object lockObj = new object();
		public static ws_StoreItemReceiveDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_StoreItemReceiveDAO();
			}
			return instance;
		}
		public static ws_StoreItemReceiveDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_StoreItemReceiveDAO();
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

		public ws_StoreItemReceiveDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_StoreItemReceive> Get(string? number = null)
		{
			try
			{
				List<ws_StoreItemReceive> ws_StoreItemReceiveLst = new List<ws_StoreItemReceive>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramNumber", number, DbType.string, ParameterDirection.Input)
				};
				ws_StoreItemReceiveLst = dbExecutor.FetchData<ws_StoreItemReceive>(CommandType.StoredProcedure, "wsp_ws_StoreItemReceive_Get", colparameters);
				return ws_StoreItemReceiveLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_StoreItemReceive> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_StoreItemReceive> ws_StoreItemReceiveLst = new List<ws_StoreItemReceive>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_StoreItemReceiveLst = dbExecutor.FetchData<ws_StoreItemReceive>(CommandType.StoredProcedure, "wsp_ws_StoreItemReceive_GetDynamic", colparameters);
				return ws_StoreItemReceiveLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_StoreItemReceive> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_StoreItemReceive> ws_StoreItemReceiveLst = new List<ws_StoreItemReceive>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_StoreItemReceiveLst = dbExecutor.FetchDataRef<ws_StoreItemReceive>(CommandType.StoredProcedure, "ws_StoreItemReceive_GetPaged", colparameters, ref rows);
				return ws_StoreItemReceiveLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_StoreItemReceive _ws_StoreItemReceive, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[15]{
				new Parameters("@paramNumber", _ws_StoreItemReceive.Number, DbType., ParameterDirection.Input),
				new Parameters("@paramReceiveDate", _ws_StoreItemReceive.ReceiveDate, DbType., ParameterDirection.Input),
				new Parameters("@paramReceivedByEmployeeId", _ws_StoreItemReceive.ReceivedByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramInspectedByEmployeeId", _ws_StoreItemReceive.InspectedByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRequistionSlipNo", _ws_StoreItemReceive.RequistionSlipNo, DbType., ParameterDirection.Input),
				new Parameters("@paramStoreIssueNumber", _ws_StoreItemReceive.StoreIssueNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramManualReferenceNumber", _ws_StoreItemReceive.ManualReferenceNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramCounterId", _ws_StoreItemReceive.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRemarks", _ws_StoreItemReceive.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramApprovalStatusId", _ws_StoreItemReceive.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ws_StoreItemReceive.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _ws_StoreItemReceive.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ws_StoreItemReceive.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ws_StoreItemReceive.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_StoreItemReceive_Post", colparameters, true);
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
