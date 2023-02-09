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
	public class inv_StockLedgerDAO : IDisposable
	{
		private static volatile inv_StockLedgerDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StockLedgerDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StockLedgerDAO();
			}
			return instance;
		}
		public static inv_StockLedgerDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StockLedgerDAO();
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

		public inv_StockLedgerDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_StockLedger> Get(Int32? id = null)
		{
			try
			{
				List<inv_StockLedger> inv_StockLedgerLst = new List<inv_StockLedger>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_StockLedgerLst = dbExecutor.FetchData<inv_StockLedger>(CommandType.StoredProcedure, "wsp_inv_StockLedger_Get", colparameters);
				return inv_StockLedgerLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_StockLedger> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_StockLedger> inv_StockLedgerLst = new List<inv_StockLedger>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_StockLedgerLst = dbExecutor.FetchData<inv_StockLedger>(CommandType.StoredProcedure, "wsp_inv_StockLedger_GetDynamic", colparameters);
				return inv_StockLedgerLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StockLedger> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StockLedger> inv_StockLedgerLst = new List<inv_StockLedger>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_StockLedgerLst = dbExecutor.FetchDataRef<inv_StockLedger>(CommandType.StoredProcedure, "inv_StockLedger_GetPaged", colparameters, ref rows);
				return inv_StockLedgerLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_StockLedger _inv_StockLedger, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[18]{
				new Parameters("@paramId", _inv_StockLedger.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramStoreId", _inv_StockLedger.StoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRackId", _inv_StockLedger.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramTransactionDate", _inv_StockLedger.TransactionDate, DbType., ParameterDirection.Input),
				new Parameters("@paramItemId", _inv_StockLedger.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramOpeingStockQty", _inv_StockLedger.OpeingStockQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOpeningStockUnitPrice", _inv_StockLedger.OpeningStockUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramStockReceiveQty", _inv_StockLedger.StockReceiveQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramStockReceiveUnitPrice", _inv_StockLedger.StockReceiveUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramStockIssueQty", _inv_StockLedger.StockIssueQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramStockIssueUnitPrice", _inv_StockLedger.StockIssueUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramStockAdjustedIncrementQty", _inv_StockLedger.StockAdjustedIncrementQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramStockAdjustedIncrementUnitPrice", _inv_StockLedger.StockAdjustedIncrementUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramStockAdjustedDecrementQty", _inv_StockLedger.StockAdjustedDecrementQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramStockAdjustedDecrementUnitPrice", _inv_StockLedger.StockAdjustedDecrementUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramClosingStockQty", _inv_StockLedger.ClosingStockQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramClosingUnitPrice", _inv_StockLedger.ClosingUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_StockLedger_Post", colparameters, true);
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
