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
	public class inv_DemagedItemStockLedgerDAO : IDisposable
	{
		private static volatile inv_DemagedItemStockLedgerDAO instance;
		private static readonly object lockObj = new object();
		public static inv_DemagedItemStockLedgerDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_DemagedItemStockLedgerDAO();
			}
			return instance;
		}
		public static inv_DemagedItemStockLedgerDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_DemagedItemStockLedgerDAO();
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

		public inv_DemagedItemStockLedgerDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_DemagedItemStockLedger> Get(Int32? id = null)
		{
			try
			{
				List<inv_DemagedItemStockLedger> inv_DemagedItemStockLedgerLst = new List<inv_DemagedItemStockLedger>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_DemagedItemStockLedgerLst = dbExecutor.FetchData<inv_DemagedItemStockLedger>(CommandType.StoredProcedure, "wsp_inv_DemagedItemStockLedger_Get", colparameters);
				return inv_DemagedItemStockLedgerLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_DemagedItemStockLedger> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_DemagedItemStockLedger> inv_DemagedItemStockLedgerLst = new List<inv_DemagedItemStockLedger>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_DemagedItemStockLedgerLst = dbExecutor.FetchData<inv_DemagedItemStockLedger>(CommandType.StoredProcedure, "wsp_inv_DemagedItemStockLedger_GetDynamic", colparameters);
				return inv_DemagedItemStockLedgerLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_DemagedItemStockLedger> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_DemagedItemStockLedger> inv_DemagedItemStockLedgerLst = new List<inv_DemagedItemStockLedger>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_DemagedItemStockLedgerLst = dbExecutor.FetchDataRef<inv_DemagedItemStockLedger>(CommandType.StoredProcedure, "inv_DemagedItemStockLedger_GetPaged", colparameters, ref rows);
				return inv_DemagedItemStockLedgerLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_DemagedItemStockLedger _inv_DemagedItemStockLedger, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[18]{
				new Parameters("@paramId", _inv_DemagedItemStockLedger.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramOStoreId", _inv_DemagedItemStockLedger.OStoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramORackId", _inv_DemagedItemStockLedger.ORackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramOTransactionDate", _inv_DemagedItemStockLedger.OTransactionDate, DbType., ParameterDirection.Input),
				new Parameters("@paramOItemId", _inv_DemagedItemStockLedger.OItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramOOpeingStockQty", _inv_DemagedItemStockLedger.OOpeingStockQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOOpeningStockUnitPrice", _inv_DemagedItemStockLedger.OOpeningStockUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOStockReceiveQty", _inv_DemagedItemStockLedger.OStockReceiveQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOStockReceiveUnitPrice", _inv_DemagedItemStockLedger.OStockReceiveUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOStockIssueQty", _inv_DemagedItemStockLedger.OStockIssueQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOStockIssueUnitPrice", _inv_DemagedItemStockLedger.OStockIssueUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOStockAdjustedIncrementQty", _inv_DemagedItemStockLedger.OStockAdjustedIncrementQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOStockAdjustedIncrementUnitPrice", _inv_DemagedItemStockLedger.OStockAdjustedIncrementUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOStockAdjustedDecrementQty", _inv_DemagedItemStockLedger.OStockAdjustedDecrementQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOStockAdjustedDecrementUnitPrice", _inv_DemagedItemStockLedger.OStockAdjustedDecrementUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOClosingStockQty", _inv_DemagedItemStockLedger.OClosingStockQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOClosingUnitPrice", _inv_DemagedItemStockLedger.OClosingUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_DemagedItemStockLedger_Post", colparameters, true);
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
