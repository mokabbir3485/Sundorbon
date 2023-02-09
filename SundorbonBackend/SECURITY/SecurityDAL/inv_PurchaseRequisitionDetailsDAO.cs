using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using DbExecutor;
using Sundorbon.Backend.SECURITY.SecurityEntity;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
	public class inv_PurchaseRequisitionDetailsDAO : IDisposable
	{
		private static volatile inv_PurchaseRequisitionDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static inv_PurchaseRequisitionDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_PurchaseRequisitionDetailsDAO();
			}
			return instance;
		}
		public static inv_PurchaseRequisitionDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_PurchaseRequisitionDetailsDAO();
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

		public inv_PurchaseRequisitionDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_PurchaseRequisitionDetails> Get(Int32? id = null)
		{
			try
			{
				List<inv_PurchaseRequisitionDetails> inv_PurchaseRequisitionDetailsLst = new List<inv_PurchaseRequisitionDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_PurchaseRequisitionDetailsLst = dbExecutor.FetchData<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "inv_PurchaseRequisitionDetails_Get", colparameters);
				return inv_PurchaseRequisitionDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_PurchaseRequisitionDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_PurchaseRequisitionDetails> inv_PurchaseRequisitionDetailsLst = new List<inv_PurchaseRequisitionDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_PurchaseRequisitionDetailsLst = dbExecutor.FetchData<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "inv_PurchaseRequisitionDetails_GetDynamic", colparameters);
				return inv_PurchaseRequisitionDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_PurchaseRequisitionDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_PurchaseRequisitionDetails> inv_PurchaseRequisitionDetailsLst = new List<inv_PurchaseRequisitionDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_PurchaseRequisitionDetailsLst = dbExecutor.FetchDataRef<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "inv_PurchaseRequisitionDetails_GetPaged", colparameters, ref rows);
				return inv_PurchaseRequisitionDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(inv_PurchaseRequisitionDetails _inv_PurchaseRequisitionDetails)
		{
			int ret =0;
			try
			{
				Parameters[] colparameters = new Parameters[6]{
				new Parameters("@Id", _inv_PurchaseRequisitionDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@PurchaseRequisitionNumber", _inv_PurchaseRequisitionDetails.PurchaseRequisitionNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ItemId", _inv_PurchaseRequisitionDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RequestedQty", _inv_PurchaseRequisitionDetails.RequestedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@IsVoid", _inv_PurchaseRequisitionDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@Remarks", _inv_PurchaseRequisitionDetails.Remarks, DbType.String, ParameterDirection.Input),

				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure,"inv_PurchaseRequisitionDetails_Post", colparameters, true);
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

		public int PostIntoPurchaseRequisitionDetailsLog(inv_PurchaseRequisitionDetails _inv_PurchaseRequisitionDetails,string transactionType)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[7]{
				new Parameters("@Id", _inv_PurchaseRequisitionDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@PurchaseRequisitionNumber", _inv_PurchaseRequisitionDetails.PurchaseRequisitionNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ItemId", _inv_PurchaseRequisitionDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RequestedQty", _inv_PurchaseRequisitionDetails.RequestedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@IsVoid", _inv_PurchaseRequisitionDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@Remarks", _inv_PurchaseRequisitionDetails.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@TransactionType", transactionType, DbType.String, ParameterDirection.Input),
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "inv_PurchaseRequisitionDetails_Log_Post", colparameters, true);
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
