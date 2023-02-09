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
    public class ws_OutdoorJobDAO
    {
		private static volatile ws_OutdoorJobDAO instance;
		private static readonly object lockObj = new object();
		public static ws_OutdoorJobDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_OutdoorJobDAO();
			}
			return instance;
		}
		public static ws_OutdoorJobDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_OutdoorJobDAO();
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

		public ws_OutdoorJobDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}


		public List<ws_OutdoorJob> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_OutdoorJob> ws_OutdoorJobLst = new List<ws_OutdoorJob>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_OutdoorJobLst = dbExecutor.FetchDataRef<ws_OutdoorJob>(CommandType.StoredProcedure, "ws_OutdoorJob_GetPaged", colparameters, ref rows);
				return ws_OutdoorJobLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        //public List<ws_OutdoorJob> GetAll()
        //{
        //	try
        //	{
        //		List<ws_OutdoorJob> ws_OutdoorJobLst = new List<ws_OutdoorJob>();
        //		ws_OutdoorJobLst = dbExecutor.FetchData<ws_OutdoorJob>(CommandType.StoredProcedure, "ws_GetAllJob");
        //		return ws_OutdoorJobLst;
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}
        public List<ws_OutdoorJob> GetAllPendingJob()
        {
            try
            {
                List<ws_OutdoorJob> ws_OutdoorJobLst = new List<ws_OutdoorJob>();
                ws_OutdoorJobLst = dbExecutor.FetchData<ws_OutdoorJob>(CommandType.StoredProcedure, "ws_OutdoorJob_Pending_GetAll_");
                return ws_OutdoorJobLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ws_OutdoorJobItemDetails> GetAllJobItem(string Number)
		{
			try
			{
				List<ws_OutdoorJobItemDetails> ws_OutdoorJobDetailsList = new List<ws_OutdoorJobItemDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

				};
				ws_OutdoorJobDetailsList = dbExecutor.FetchData<ws_OutdoorJobItemDetails>(CommandType.StoredProcedure, "ws_OutdoorJobItemDetails_GetAll_By_JobNumber", colparameters);
				return ws_OutdoorJobDetailsList;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public string Post(ws_OutdoorJob _ws_OutdoorJob, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[15]{

				new Parameters("@Number", _ws_OutdoorJob.Number, DbType.String, ParameterDirection.Input),
				new Parameters("@PurposeId", _ws_OutdoorJob.PurposeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@OutdoorJobDate", _ws_OutdoorJob.OutdoorJobDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@CounterId", _ws_OutdoorJob.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@JobCreatedByEmployeeId", _ws_OutdoorJob.JobCreatedByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@VehicleId", _ws_OutdoorJob.VehicleId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@DriverInformation", _ws_OutdoorJob.DriverInformation, DbType.String, ParameterDirection.Input),
				new Parameters("@Remarks", _ws_OutdoorJob.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@ApprovalStatusId", _ws_OutdoorJob.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _ws_OutdoorJob.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreationDate", _ws_OutdoorJob.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ws_OutdoorJob.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdateDate", _ws_OutdoorJob.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@TransactiontionType", transactionType, DbType.String, ParameterDirection.Input),
				new Parameters("@VendorName", _ws_OutdoorJob.VendorName, DbType.String, ParameterDirection.Input),

				};

				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "ws_OutdoorJob_Post", colparameters, true);
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
