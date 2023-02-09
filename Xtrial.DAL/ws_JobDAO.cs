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
	public class ws_JobDAO : IDisposable
	{
		private static volatile ws_JobDAO instance;
		private static readonly object lockObj = new object();
		public static ws_JobDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_JobDAO();
			}
			return instance;
		}
		public static ws_JobDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_JobDAO();
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

		public ws_JobDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_Job> Get(string? number = null)
		{
			try
			{
				List<ws_Job> ws_JobLst = new List<ws_Job>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramNumber", number, DbType.string, ParameterDirection.Input)
				};
				ws_JobLst = dbExecutor.FetchData<ws_Job>(CommandType.StoredProcedure, "wsp_ws_Job_Get", colparameters);
				return ws_JobLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_Job> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_Job> ws_JobLst = new List<ws_Job>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_JobLst = dbExecutor.FetchData<ws_Job>(CommandType.StoredProcedure, "wsp_ws_Job_GetDynamic", colparameters);
				return ws_JobLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_Job> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_Job> ws_JobLst = new List<ws_Job>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_JobLst = dbExecutor.FetchDataRef<ws_Job>(CommandType.StoredProcedure, "ws_Job_GetPaged", colparameters, ref rows);
				return ws_JobLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_Job _ws_Job, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[14]{
				new Parameters("@paramNumber", _ws_Job.Number, DbType., ParameterDirection.Input),
				new Parameters("@paramJobDate", _ws_Job.JobDate, DbType., ParameterDirection.Input),
				new Parameters("@paramVehicleId", _ws_Job.VehicleId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramJobCreatedByEmployeeId", _ws_Job.JobCreatedByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramPurposeId", _ws_Job.PurposeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCounterId", _ws_Job.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDriverInformation", _ws_Job.DriverInformation, DbType., ParameterDirection.Input),
				new Parameters("@paramRemarks", _ws_Job.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramApprovalStatusId", _ws_Job.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ws_Job.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _ws_Job.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ws_Job.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ws_Job.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_Job_Post", colparameters, true);
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
