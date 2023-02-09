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
	public class inv_OpeingStockDAO : IDisposable
	{
		private static volatile inv_OpeingStockDAO instance;
		private static readonly object lockObj = new object();
		public static inv_OpeingStockDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_OpeingStockDAO();
			}
			return instance;
		}
		public static inv_OpeingStockDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_OpeingStockDAO();
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

		public inv_OpeingStockDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_OpeingStock> Get(Int32? id = null)
		{
			try
			{
				List<inv_OpeingStock> inv_OpeingStockLst = new List<inv_OpeingStock>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_OpeingStockLst = dbExecutor.FetchData<inv_OpeingStock>(CommandType.StoredProcedure, "wsp_inv_OpeingStock_Get", colparameters);
				return inv_OpeingStockLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_OpeingStock> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_OpeingStock> inv_OpeingStockLst = new List<inv_OpeingStock>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_OpeingStockLst = dbExecutor.FetchData<inv_OpeingStock>(CommandType.StoredProcedure, "wsp_inv_OpeingStock_GetDynamic", colparameters);
				return inv_OpeingStockLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_OpeingStock> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_OpeingStock> inv_OpeingStockLst = new List<inv_OpeingStock>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_OpeingStockLst = dbExecutor.FetchDataRef<inv_OpeingStock>(CommandType.StoredProcedure, "inv_OpeingStock_GetPaged", colparameters, ref rows);
				return inv_OpeingStockLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_OpeingStock _inv_OpeingStock, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramId", _inv_OpeingStock.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramStoreId", _inv_OpeingStock.StoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRackId", _inv_OpeingStock.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramOpeningDate", _inv_OpeingStock.OpeningDate, DbType., ParameterDirection.Input),
				new Parameters("@paramItemId", _inv_OpeingStock.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramOpeningQty", _inv_OpeingStock.OpeningQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOpeningUnitPrice", _inv_OpeingStock.OpeningUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDamagedItemQty", _inv_OpeingStock.DamagedItemQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDemagedItemUnitPrice", _inv_OpeingStock.DemagedItemUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_OpeingStock_Post", colparameters, true);
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
