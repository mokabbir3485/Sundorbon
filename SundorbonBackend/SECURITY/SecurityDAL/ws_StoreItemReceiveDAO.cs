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
    public class ws_StoreItemReceiveDAO
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
		public string Post(ws_StoreItemReceive _ws_StoreItemReceive)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[15]{

				new Parameters("@Number", _ws_StoreItemReceive.Number, DbType.String, ParameterDirection.Input),
				new Parameters("@ReceiveDate", _ws_StoreItemReceive.ReceiveDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@ReceivedByEmployeeId", _ws_StoreItemReceive.ReceivedByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@InspectedByEmployeeId", _ws_StoreItemReceive.InspectedByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RequistionSlipNo", _ws_StoreItemReceive.RequistionSlipNo, DbType.String, ParameterDirection.Input),
				new Parameters("@StoreIssueNumber", _ws_StoreItemReceive.StoreIssueNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ManualReferenceNumber", _ws_StoreItemReceive.ManualReferenceNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@CounterId", _ws_StoreItemReceive.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Remarks", _ws_StoreItemReceive.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@ApprovalStatusId", _ws_StoreItemReceive.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _ws_StoreItemReceive.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreateDate", _ws_StoreItemReceive.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ws_StoreItemReceive.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdateDate", _ws_StoreItemReceive.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@TransactiontionType", _ws_StoreItemReceive.TransactiontionType, DbType.String, ParameterDirection.Input),

				};

				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "ws_StoreItemReceive_Post", colparameters, true);
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
		public List<ws_StoreItemReceive> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_StoreItemReceive> inv_PurchaseRequisitionLst = new List<ws_StoreItemReceive>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchDataRef<ws_StoreItemReceive>(CommandType.StoredProcedure, "ws_StoreItemReceive_GetPaged", colparameters, ref rows);
				return inv_PurchaseRequisitionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_StoreItemReceiveDetails> GetAll( string Number)
		{
			try
			{
				List<ws_StoreItemReceiveDetails> ws_JobDetailsLst = new List<ws_StoreItemReceiveDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input)
				};
				ws_JobDetailsLst = dbExecutor.FetchData<ws_StoreItemReceiveDetails>(CommandType.StoredProcedure, "ws_StoreItemReceiveDetails_GetAll", colparameters);
				return ws_JobDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
