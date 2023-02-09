using DbExecutor;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
    public class inv_StockAuditDetailsDAO
    {
		private static volatile inv_StockAuditDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StockAuditDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StockAuditDetailsDAO();
			}
			return instance;
		}
		public static inv_StockAuditDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StockAuditDetailsDAO();
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

		public inv_StockAuditDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_StockAuditDetails> Get(int Id)
		{
			try
			{
				List<inv_StockAuditDetails> inv_StockAuditDetailsLst = new List<inv_StockAuditDetails>();
				Parameters[] colparameters = new Parameters[]{
				new Parameters("@Id", Id, DbType.Int32, ParameterDirection.Input)
				};
				inv_StockAuditDetailsLst = dbExecutor.FetchData<inv_StockAuditDetails>(CommandType.StoredProcedure, "inv_StockAuditDetails_Get", colparameters);
				return inv_StockAuditDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StockAuditDetails> GetAllAdjustmentDetailsFromAdjustmentId(string Id)
		{
			try
			{
				List<inv_StockAuditDetails> inv_StockAuditDetailsLst = new List<inv_StockAuditDetails>();
				Parameters[] colparameters = new Parameters[]{
				new Parameters("@StockAuditId", Id, DbType.String, ParameterDirection.Input)
				};
				inv_StockAuditDetailsLst = dbExecutor.FetchData<inv_StockAuditDetails>(CommandType.StoredProcedure, "inv_StockAuditDetails_GetAll_From_StockAuditId", colparameters);
				return inv_StockAuditDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StockAuditDetails> GetDynamic(string whereCondition, string orderByExpression)
		{
			try
			{
				List<inv_StockAuditDetails> inv_StockAuditDetailsLst = new List<inv_StockAuditDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_StockAuditDetailsLst = dbExecutor.FetchData<inv_StockAuditDetails>(CommandType.StoredProcedure, "inv_StockAuditDetails_GetDynamic", colparameters);
				return inv_StockAuditDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StockAuditDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StockAuditDetails> inv_StockAuditDetailsLst = new List<inv_StockAuditDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_StockAuditDetailsLst = dbExecutor.FetchDataRef<inv_StockAuditDetails>(CommandType.StoredProcedure, "inv_StockAuditDetails_GetPaged", colparameters, ref rows);
				return inv_StockAuditDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(inv_StockAuditDetails _inv_StockAuditDetails)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@Id", _inv_StockAuditDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@StockAuditId", _inv_StockAuditDetails.StockAuditId, DbType.String, ParameterDirection.Input),
				new Parameters("@RackId", _inv_StockAuditDetails.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@PhysicalStockQty", _inv_StockAuditDetails.PhysicalStockQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@OldStockQty", _inv_StockAuditDetails.OldStockQty, DbType.Decimal, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "inv_StockAuditDetails_Post", colparameters, true);
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
