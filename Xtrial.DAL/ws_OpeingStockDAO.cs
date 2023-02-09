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
	public class ws_OpeingStockDAO : IDisposable
	{
		private static volatile ws_OpeingStockDAO instance;
		private static readonly object lockObj = new object();
		public static ws_OpeingStockDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_OpeingStockDAO();
			}
			return instance;
		}
		public static ws_OpeingStockDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_OpeingStockDAO();
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

		public ws_OpeingStockDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_OpeingStock> Get(Int32? id = null)
		{
			try
			{
				List<ws_OpeingStock> ws_OpeingStockLst = new List<ws_OpeingStock>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ws_OpeingStockLst = dbExecutor.FetchData<ws_OpeingStock>(CommandType.StoredProcedure, "wsp_ws_OpeingStock_Get", colparameters);
				return ws_OpeingStockLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_OpeingStock> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_OpeingStock> ws_OpeingStockLst = new List<ws_OpeingStock>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_OpeingStockLst = dbExecutor.FetchData<ws_OpeingStock>(CommandType.StoredProcedure, "wsp_ws_OpeingStock_GetDynamic", colparameters);
				return ws_OpeingStockLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_OpeingStock> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_OpeingStock> ws_OpeingStockLst = new List<ws_OpeingStock>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_OpeingStockLst = dbExecutor.FetchDataRef<ws_OpeingStock>(CommandType.StoredProcedure, "ws_OpeingStock_GetPaged", colparameters, ref rows);
				return ws_OpeingStockLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_OpeingStock _ws_OpeingStock, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramId", _ws_OpeingStock.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramStoreId", _ws_OpeingStock.StoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRackId", _ws_OpeingStock.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramOpeningDate", _ws_OpeingStock.OpeningDate, DbType., ParameterDirection.Input),
				new Parameters("@paramItemId", _ws_OpeingStock.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramOpeningQty", _ws_OpeingStock.OpeningQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramOpeningUnitPrice", _ws_OpeingStock.OpeningUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDamagedItemQty", _ws_OpeingStock.DamagedItemQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDemagedItemUnitPrice", _ws_OpeingStock.DemagedItemUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_OpeingStock_Post", colparameters, true);
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
