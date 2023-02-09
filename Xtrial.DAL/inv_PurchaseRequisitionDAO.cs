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
	public class inv_PurchaseRequisitionDAO : IDisposable
	{
		private static volatile inv_PurchaseRequisitionDAO instance;
		private static readonly object lockObj = new object();
		public static inv_PurchaseRequisitionDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_PurchaseRequisitionDAO();
			}
			return instance;
		}
		public static inv_PurchaseRequisitionDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_PurchaseRequisitionDAO();
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

		public inv_PurchaseRequisitionDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_PurchaseRequisition> Get(string? number = null)
		{
			try
			{
				List<inv_PurchaseRequisition> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisition>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramNumber", number, DbType.string, ParameterDirection.Input)
				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PurchaseRequisition>(CommandType.StoredProcedure, "wsp_inv_PurchaseRequisition_Get", colparameters);
				return inv_PurchaseRequisitionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_PurchaseRequisition> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_PurchaseRequisition> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisition>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchData<inv_PurchaseRequisition>(CommandType.StoredProcedure, "wsp_inv_PurchaseRequisition_GetDynamic", colparameters);
				return inv_PurchaseRequisitionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_PurchaseRequisition> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_PurchaseRequisition> inv_PurchaseRequisitionLst = new List<inv_PurchaseRequisition>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_PurchaseRequisitionLst = dbExecutor.FetchDataRef<inv_PurchaseRequisition>(CommandType.StoredProcedure, "inv_PurchaseRequisition_GetPaged", colparameters, ref rows);
				return inv_PurchaseRequisitionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_PurchaseRequisition _inv_PurchaseRequisition, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramNumber", _inv_PurchaseRequisition.Number, DbType., ParameterDirection.Input),
				new Parameters("@paramRequisitionDate", _inv_PurchaseRequisition.RequisitionDate, DbType., ParameterDirection.Input),
				new Parameters("@paramCounterId", _inv_PurchaseRequisition.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRequestedByEmployeeId", _inv_PurchaseRequisition.RequestedByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramApprovalStatusId", _inv_PurchaseRequisition.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _inv_PurchaseRequisition.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _inv_PurchaseRequisition.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _inv_PurchaseRequisition.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _inv_PurchaseRequisition.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_PurchaseRequisition_Post", colparameters, true);
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
