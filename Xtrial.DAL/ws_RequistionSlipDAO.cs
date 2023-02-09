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
	public class ws_RequistionSlipDAO : IDisposable
	{
		private static volatile ws_RequistionSlipDAO instance;
		private static readonly object lockObj = new object();
		public static ws_RequistionSlipDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_RequistionSlipDAO();
			}
			return instance;
		}
		public static ws_RequistionSlipDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_RequistionSlipDAO();
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

		public ws_RequistionSlipDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_RequistionSlip> Get(string? number = null)
		{
			try
			{
				List<ws_RequistionSlip> ws_RequistionSlipLst = new List<ws_RequistionSlip>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramNumber", number, DbType.string, ParameterDirection.Input)
				};
				ws_RequistionSlipLst = dbExecutor.FetchData<ws_RequistionSlip>(CommandType.StoredProcedure, "wsp_ws_RequistionSlip_Get", colparameters);
				return ws_RequistionSlipLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_RequistionSlip> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_RequistionSlip> ws_RequistionSlipLst = new List<ws_RequistionSlip>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_RequistionSlipLst = dbExecutor.FetchData<ws_RequistionSlip>(CommandType.StoredProcedure, "wsp_ws_RequistionSlip_GetDynamic", colparameters);
				return ws_RequistionSlipLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_RequistionSlip> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_RequistionSlip> ws_RequistionSlipLst = new List<ws_RequistionSlip>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_RequistionSlipLst = dbExecutor.FetchDataRef<ws_RequistionSlip>(CommandType.StoredProcedure, "ws_RequistionSlip_GetPaged", colparameters, ref rows);
				return ws_RequistionSlipLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_RequistionSlip _ws_RequistionSlip, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[14]{
				new Parameters("@paramNumber", _ws_RequistionSlip.Number, DbType., ParameterDirection.Input),
				new Parameters("@paramRequistionDate", _ws_RequistionSlip.RequistionDate, DbType., ParameterDirection.Input),
				new Parameters("@paramCounterId", _ws_RequistionSlip.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramJobNumber", _ws_RequistionSlip.JobNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramManualReferenceNo", _ws_RequistionSlip.ManualReferenceNo, DbType., ParameterDirection.Input),
				new Parameters("@paramRequistionGivenByEmployeeId", _ws_RequistionSlip.RequistionGivenByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRequistionSlipTypeId", _ws_RequistionSlip.RequistionSlipTypeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRemarks", _ws_RequistionSlip.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramApprovalStatusId", _ws_RequistionSlip.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ws_RequistionSlip.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _ws_RequistionSlip.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ws_RequistionSlip.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ws_RequistionSlip.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_RequistionSlip_Post", colparameters, true);
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
