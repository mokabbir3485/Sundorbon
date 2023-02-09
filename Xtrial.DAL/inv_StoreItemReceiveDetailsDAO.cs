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
	public class inv_StoreItemReceiveDetailsDAO : IDisposable
	{
		private static volatile inv_StoreItemReceiveDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StoreItemReceiveDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StoreItemReceiveDetailsDAO();
			}
			return instance;
		}
		public static inv_StoreItemReceiveDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StoreItemReceiveDetailsDAO();
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

		public inv_StoreItemReceiveDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_StoreItemReceiveDetails> Get(Int32? id = null)
		{
			try
			{
				List<inv_StoreItemReceiveDetails> inv_StoreItemReceiveDetailsLst = new List<inv_StoreItemReceiveDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_StoreItemReceiveDetailsLst = dbExecutor.FetchData<inv_StoreItemReceiveDetails>(CommandType.StoredProcedure, "wsp_inv_StoreItemReceiveDetails_Get", colparameters);
				return inv_StoreItemReceiveDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_StoreItemReceiveDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_StoreItemReceiveDetails> inv_StoreItemReceiveDetailsLst = new List<inv_StoreItemReceiveDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_StoreItemReceiveDetailsLst = dbExecutor.FetchData<inv_StoreItemReceiveDetails>(CommandType.StoredProcedure, "wsp_inv_StoreItemReceiveDetails_GetDynamic", colparameters);
				return inv_StoreItemReceiveDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StoreItemReceiveDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StoreItemReceiveDetails> inv_StoreItemReceiveDetailsLst = new List<inv_StoreItemReceiveDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_StoreItemReceiveDetailsLst = dbExecutor.FetchDataRef<inv_StoreItemReceiveDetails>(CommandType.StoredProcedure, "inv_StoreItemReceiveDetails_GetPaged", colparameters, ref rows);
				return inv_StoreItemReceiveDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_StoreItemReceiveDetails _inv_StoreItemReceiveDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@paramId", _inv_StoreItemReceiveDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramStoreReceiveNumber", _inv_StoreItemReceiveDetails.StoreReceiveNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramStoreReceiveId", _inv_StoreItemReceiveDetails.StoreReceiveId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramStoreRackId", _inv_StoreItemReceiveDetails.StoreRackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramItemId", _inv_StoreItemReceiveDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramReceivedQty", _inv_StoreItemReceiveDetails.ReceivedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramReceivedUnitPrice", _inv_StoreItemReceiveDetails.ReceivedUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_StoreItemReceiveDetails_Post", colparameters, true);
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
