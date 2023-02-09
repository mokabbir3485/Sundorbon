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
	public class ws_DamagedItemStockLedgerDAO : IDisposable
	{
		private static volatile ws_DamagedItemStockLedgerDAO instance;
		private static readonly object lockObj = new object();
		public static ws_DamagedItemStockLedgerDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_DamagedItemStockLedgerDAO();
			}
			return instance;
		}
		public static ws_DamagedItemStockLedgerDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_DamagedItemStockLedgerDAO();
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

		public ws_DamagedItemStockLedgerDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_DamagedItemStockLedger> Get(Int32? id = null)
		{
			try
			{
				List<ws_DamagedItemStockLedger> ws_DamagedItemStockLedgerLst = new List<ws_DamagedItemStockLedger>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ws_DamagedItemStockLedgerLst = dbExecutor.FetchData<ws_DamagedItemStockLedger>(CommandType.StoredProcedure, "wsp_ws_DamagedItemStockLedger_Get", colparameters);
				return ws_DamagedItemStockLedgerLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_DamagedItemStockLedger> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_DamagedItemStockLedger> ws_DamagedItemStockLedgerLst = new List<ws_DamagedItemStockLedger>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_DamagedItemStockLedgerLst = dbExecutor.FetchData<ws_DamagedItemStockLedger>(CommandType.StoredProcedure, "wsp_ws_DamagedItemStockLedger_GetDynamic", colparameters);
				return ws_DamagedItemStockLedgerLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_DamagedItemStockLedger> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_DamagedItemStockLedger> ws_DamagedItemStockLedgerLst = new List<ws_DamagedItemStockLedger>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_DamagedItemStockLedgerLst = dbExecutor.FetchDataRef<ws_DamagedItemStockLedger>(CommandType.StoredProcedure, "ws_DamagedItemStockLedger_GetPaged", colparameters, ref rows);
				return ws_DamagedItemStockLedgerLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_DamagedItemStockLedger _ws_DamagedItemStockLedger, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[18]{
				new Parameters("@paramId", _ws_DamagedItemStockLedger.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDStoreId", _ws_DamagedItemStockLedger.DStoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDRackId", _ws_DamagedItemStockLedger.DRackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDTransactionDate", _ws_DamagedItemStockLedger.DTransactionDate, DbType., ParameterDirection.Input),
				new Parameters("@paramDItemId", _ws_DamagedItemStockLedger.DItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDOpeingStockQty", _ws_DamagedItemStockLedger.DOpeingStockQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDOpeningStockUnitPrice", _ws_DamagedItemStockLedger.DOpeningStockUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDStockReceiveQty", _ws_DamagedItemStockLedger.DStockReceiveQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDStockReceiveUnitPrice", _ws_DamagedItemStockLedger.DStockReceiveUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDStockIssueQty", _ws_DamagedItemStockLedger.DStockIssueQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDStockIssueUnitPrice", _ws_DamagedItemStockLedger.DStockIssueUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDStockAdjustedIncrementQty", _ws_DamagedItemStockLedger.DStockAdjustedIncrementQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDStockAdjustedIncrementUnitPrice", _ws_DamagedItemStockLedger.DStockAdjustedIncrementUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDStockAdjustedDecrementQty", _ws_DamagedItemStockLedger.DStockAdjustedDecrementQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDStockAdjustedDecrementUnitPrice", _ws_DamagedItemStockLedger.DStockAdjustedDecrementUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDClosingStockQty", _ws_DamagedItemStockLedger.DClosingStockQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDClosingUnitPrice", _ws_DamagedItemStockLedger.DClosingUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_DamagedItemStockLedger_Post", colparameters, true);
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
