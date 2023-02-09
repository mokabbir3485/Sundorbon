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
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_PurchaseRequisitionDetailsLst = dbExecutor.FetchData<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "wsp_inv_PurchaseRequisitionDetails_Get", colparameters);
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
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_PurchaseRequisitionDetailsLst = dbExecutor.FetchData<inv_PurchaseRequisitionDetails>(CommandType.StoredProcedure, "wsp_inv_PurchaseRequisitionDetails_GetDynamic", colparameters);
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
		public string Post(inv_PurchaseRequisitionDetails _inv_PurchaseRequisitionDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[7]{
				new Parameters("@paramId", _inv_PurchaseRequisitionDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramPurchaseRequisitionNumber", _inv_PurchaseRequisitionDetails.PurchaseRequisitionNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramItemId", _inv_PurchaseRequisitionDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRequestedQty", _inv_PurchaseRequisitionDetails.RequestedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramIsVoid", _inv_PurchaseRequisitionDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramRemarks", _inv_PurchaseRequisitionDetails.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_PurchaseRequisitionDetails_Post", colparameters, true);
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
