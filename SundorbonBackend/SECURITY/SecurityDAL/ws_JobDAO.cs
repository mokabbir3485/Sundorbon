using DbExecutor;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
    public class ws_JobDAO
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

		//public List<xrpt_ws_Job> Get()
		//{
		//	try
		//	{
		//		List<xrpt_ws_Job> ws_JobLst = new List<xrpt_ws_Job>();

		//		ws_JobLst = dbExecutor.FetchData<xrpt_ws_Job>(CommandType.StoredProcedure, "ws_Job_GetAll");
		//		return ws_JobLst;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}

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
		public List<ws_Job> GetAll()
		{
			try
			{
				List<ws_Job> ws_JobLst = new List<ws_Job>();
				ws_JobLst = dbExecutor.FetchData<ws_Job>(CommandType.StoredProcedure, "ws_GetAllJob");
				return ws_JobLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_Job> GetAllPendingJob()
		{
			try
			{
				List<ws_Job> ws_JobLst = new List<ws_Job>();
				ws_JobLst = dbExecutor.FetchData<ws_Job>(CommandType.StoredProcedure, "ws_Job_Pending_GetAll_");
				return ws_JobLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_JobItemDetails> GetAllJobItem(string Number)
		{
			try
			{
				List<ws_JobItemDetails> ws_JobDetailsList = new List<ws_JobItemDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

				};
				ws_JobDetailsList = dbExecutor.FetchData<ws_JobItemDetails>(CommandType.StoredProcedure, "ws_JobItemDetails_GetAll_By_JobNumber", colparameters);
				return ws_JobDetailsList;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		


		public string Post(ws_Job _ws_Job,string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[14]{

				new Parameters("@Number", _ws_Job.Number, DbType.String, ParameterDirection.Input),
				new Parameters("@PurposeId", _ws_Job.PurposeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@JobDate", _ws_Job.JobDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@CounterId", _ws_Job.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@JobCreatedByEmployeeId", _ws_Job.JobCreatedByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@VehicleId", _ws_Job.VehicleId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@DriverInformation", _ws_Job.DriverInformation, DbType.String, ParameterDirection.Input),
				new Parameters("@Remarks", _ws_Job.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@ApprovalStatusId", _ws_Job.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _ws_Job.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreationDate", _ws_Job.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ws_Job.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdateDate", _ws_Job.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@TransactiontionType", transactionType, DbType.String, ParameterDirection.Input),

				};

				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "ws_Job_Post", colparameters, true);
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
