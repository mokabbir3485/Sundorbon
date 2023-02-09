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
    public class ws_RequestionDAO
    {

		private static volatile ws_RequestionDAO instance;
		private static readonly object lockObj = new object();
		public static ws_RequestionDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_RequestionDAO();
			}
			return instance;
		}
		public static ws_RequestionDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_RequestionDAO();
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

		public ws_RequestionDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_RequestionSlipDetails> Get()
		{
			try
			{
				List<ws_RequestionSlipDetails> inv_PurchaseRequisitionLst = new List<ws_RequestionSlipDetails>();

				inv_PurchaseRequisitionLst = dbExecutor.FetchData<ws_RequestionSlipDetails>(CommandType.StoredProcedure, "inv_PurchaseRequisition_GetAll");
				return inv_PurchaseRequisitionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_Requestion> GetAllRequestionSlip()
		{
			try
			{
				List<ws_Requestion> inv_PurchaseRequisitionLst = new List<ws_Requestion>();

				inv_PurchaseRequisitionLst = dbExecutor.FetchData<ws_Requestion>(CommandType.StoredProcedure, "ws_GetAll_RequisitionSlip");
				return inv_PurchaseRequisitionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_Requestion> GetDynamic(string whereCondition, string orderByExpression)
		{
			try
			{
				List<ws_Requestion> inv_PurchaseRequisitionLst = new List<ws_Requestion>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchData<ws_Requestion>(CommandType.StoredProcedure, "inv_PurchaseRequisition_GetDynamic", colparameters);
				return inv_PurchaseRequisitionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
		
		public List<ws_Requestion> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_Requestion> inv_PurchaseRequisitionLst = new List<ws_Requestion>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchDataRef<ws_Requestion>(CommandType.StoredProcedure, "ws_RequistionSlip_GetPaged", colparameters, ref rows);
				return inv_PurchaseRequisitionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public List<ws_Requestion> ws_RequistionSlip_GetByIssue(DateTime? fromDate = null, DateTime? toDate = null)
		{
			try
			{
				List<ws_Requestion> ws_RequestionList = new List<ws_Requestion>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@fromDate", fromDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@toDate", toDate, DbType.DateTime, ParameterDirection.Input)
				};

				ws_RequestionList = dbExecutor.FetchData<ws_Requestion>(CommandType.StoredProcedure, "ws_RequistionSlip_GetByIssue", colparameters);
				return ws_RequestionList;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		public List<ws_RequestionSlipDetails> GetByWSRequisitionNumber(string Number)
		{
			try
			{


				List<ws_RequestionSlipDetails> inv_PurchaseRequisitionLst = new List<ws_RequestionSlipDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchData<ws_RequestionSlipDetails>(CommandType.StoredProcedure, "ws_RequistionSlipForNumber", colparameters);
				return inv_PurchaseRequisitionLst;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_RequestionSlipDetails> GetByWSRequisitionReport(string Number)
		{
			try
			{


				List<ws_RequestionSlipDetails> inv_PurchaseRequisitionLst = new List<ws_RequestionSlipDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchData<ws_RequestionSlipDetails>(CommandType.StoredProcedure, "xrpt_ws_RequistionSlipForNumber", colparameters);
				return inv_PurchaseRequisitionLst;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}






		public string Post(ws_Requestion _inv_PurchaseRequisition)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[13]{

				new Parameters("@Number", _inv_PurchaseRequisition.Number, DbType.String, ParameterDirection.Input),
				new Parameters("@RequistionDate", _inv_PurchaseRequisition.RequistionDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@CounterId", _inv_PurchaseRequisition.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@JobNumber", _inv_PurchaseRequisition.JobNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ManualReferenceNo", _inv_PurchaseRequisition.ManualReferenceNo, DbType.String, ParameterDirection.Input),
				new Parameters("@RequistionGivenByEmployeeId", _inv_PurchaseRequisition.RequistionGivenByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RequistionSlipTypeId", _inv_PurchaseRequisition.RequistionSlipTypeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@SlipAdjForDriverEmloyeeId", _inv_PurchaseRequisition.SlipAdjForDriverEmloyeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ApprovalStatusId", _inv_PurchaseRequisition.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Remarks", _inv_PurchaseRequisition.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@CreatorId", _inv_PurchaseRequisition.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _inv_PurchaseRequisition.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@TransactiontionType", _inv_PurchaseRequisition.TransactiontionType, DbType.String, ParameterDirection.Input),

				};

				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "ws_RequistionSlip_Post", colparameters, true);
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


		

	
		public List<inv_PurchaseRequisitionDetails> GetByRequisitionNumber(string Number)
		{
			try
			{


				List<inv_PurchaseRequisitionDetails> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisitionDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "inv_PurchaseRequisitionDetails_GetByRequisitionNumber", colparameters);
				return inv_PurchaseRequisitionLst;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_Requestion> GetByNumber(string Number)
		{
			try
			{
				List<ws_Requestion> inv_PurchaseRequisitionLst = new List<ws_Requestion>();
				Parameters[] colparameters = new Parameters[1]{
					new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),
				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchData<ws_Requestion>(CommandType.StoredProcedure, "inv_PurchaseRequisition_GetByNumber", colparameters);
				return inv_PurchaseRequisitionLst;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Int32 WsDetailAdd(ws_RequestionSlipDetails _ws_RequestionSlipDetails)
		{
			Int32 ret =0;
			try
			{
				Parameters[] colparameters = new Parameters[6]{
				new Parameters("@Id", _ws_RequestionSlipDetails.Id, DbType.String, ParameterDirection.Input),
				new Parameters("@RequistionSlipNumber", _ws_RequestionSlipDetails.RequistionSlipNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ItemId", _ws_RequestionSlipDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RequestedQty", _ws_RequestionSlipDetails.RequestedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@DamagedItemQty", _ws_RequestionSlipDetails.DamagedItemQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@Remarks", _ws_RequestionSlipDetails.Remarks, DbType.String, ParameterDirection.Input),

				};

				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ws_RequistionSlipDetails_Post", colparameters, true);
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
