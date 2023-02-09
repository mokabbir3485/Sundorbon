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
	public class ws_JobDetailsDAO : IDisposable
	{
		private static volatile ws_JobDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static ws_JobDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_JobDetailsDAO();
			}
			return instance;
		}
		public static ws_JobDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_JobDetailsDAO();
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

		public ws_JobDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_JobDetails> Get(Int32? id = null)
		{
			try
			{
				List<ws_JobDetails> ws_JobDetailsLst = new List<ws_JobDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ws_JobDetailsLst = dbExecutor.FetchData<ws_JobDetails>(CommandType.StoredProcedure, "wsp_ws_JobDetails_Get", colparameters);
				return ws_JobDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_JobDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_JobDetails> ws_JobDetailsLst = new List<ws_JobDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_JobDetailsLst = dbExecutor.FetchData<ws_JobDetails>(CommandType.StoredProcedure, "wsp_ws_JobDetails_GetDynamic", colparameters);
				return ws_JobDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_JobDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_JobDetails> ws_JobDetailsLst = new List<ws_JobDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_JobDetailsLst = dbExecutor.FetchDataRef<ws_JobDetails>(CommandType.StoredProcedure, "ws_JobDetails_GetPaged", colparameters, ref rows);
				return ws_JobDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_JobDetails _ws_JobDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@paramId", _ws_JobDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramJobNumber", _ws_JobDetails.JobNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramWorkDetails", _ws_JobDetails.WorkDetails, DbType., ParameterDirection.Input),
				new Parameters("@paramIsVoid", _ws_JobDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_JobDetails_Post", colparameters, true);
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
