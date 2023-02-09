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
	public class inv_StoreItemReceiveDAO : IDisposable
	{
		private static volatile inv_StoreItemReceiveDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StoreItemReceiveDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StoreItemReceiveDAO();
			}
			return instance;
		}
		public static inv_StoreItemReceiveDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StoreItemReceiveDAO();
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

		public inv_StoreItemReceiveDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_StoreItemReceive> Get(string? number = null)
		{
			try
			{
				List<inv_StoreItemReceive> inv_StoreItemReceiveLst = new List<inv_StoreItemReceive>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramNumber", number, DbType.string, ParameterDirection.Input)
				};
				inv_StoreItemReceiveLst = dbExecutor.FetchData<inv_StoreItemReceive>(CommandType.StoredProcedure, "wsp_inv_StoreItemReceive_Get", colparameters);
				return inv_StoreItemReceiveLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_StoreItemReceive> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_StoreItemReceive> inv_StoreItemReceiveLst = new List<inv_StoreItemReceive>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_StoreItemReceiveLst = dbExecutor.FetchData<inv_StoreItemReceive>(CommandType.StoredProcedure, "wsp_inv_StoreItemReceive_GetDynamic", colparameters);
				return inv_StoreItemReceiveLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StoreItemReceive> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StoreItemReceive> inv_StoreItemReceiveLst = new List<inv_StoreItemReceive>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_StoreItemReceiveLst = dbExecutor.FetchDataRef<inv_StoreItemReceive>(CommandType.StoredProcedure, "inv_StoreItemReceive_GetPaged", colparameters, ref rows);
				return inv_StoreItemReceiveLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_StoreItemReceive _inv_StoreItemReceive, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[12]{
				new Parameters("@paramNumber", _inv_StoreItemReceive.Number, DbType., ParameterDirection.Input),
				new Parameters("@paramStockReceiveDate", _inv_StoreItemReceive.StockReceiveDate, DbType., ParameterDirection.Input),
				new Parameters("@paramStockReceivedFrom", _inv_StoreItemReceive.StockReceivedFrom, DbType.Int16, ParameterDirection.Input),
				new Parameters("@paramReceivedByUserId", _inv_StoreItemReceive.ReceivedByUserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramPurchaseBillOrRequisitionSlipNo", _inv_StoreItemReceive.PurchaseBillOrRequisitionSlipNo, DbType., ParameterDirection.Input),
				new Parameters("@paramCounterId", _inv_StoreItemReceive.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRemarks", _inv_StoreItemReceive.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramCreatorId", _inv_StoreItemReceive.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _inv_StoreItemReceive.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _inv_StoreItemReceive.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _inv_StoreItemReceive.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_StoreItemReceive_Post", colparameters, true);
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
