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
    public class inv_StockAuditDAO
    {
		private static volatile inv_StockAuditDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StockAuditDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StockAuditDAO();
			}
			return instance;
		}
		public static inv_StockAuditDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StockAuditDAO();
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

		public inv_StockAuditDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_StockAudit> Get(int Id)
		{
			try
			{
				List<inv_StockAudit> inv_StockAuditLst = new List<inv_StockAudit>();
				Parameters[] colparameters = new Parameters[]{
				new Parameters("@Id", Id, DbType.Int32, ParameterDirection.Input)
				};
				inv_StockAuditLst = dbExecutor.FetchData<inv_StockAudit>(CommandType.StoredProcedure, "inv_StockAudit_Get", colparameters);
				return inv_StockAuditLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StockAudit> GetALL()
		{
			try
			{
				List<inv_StockAudit> inv_StockAuditLst = new List<inv_StockAudit>();

				inv_StockAuditLst = dbExecutor.FetchData<inv_StockAudit>(CommandType.StoredProcedure, "inv_StockAudit_GetAll");
				return inv_StockAuditLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StockAudit> GetDynamic(string whereCondition, string orderByExpression)
		{
			try
			{
				List<inv_StockAudit> inv_StockAuditLst = new List<inv_StockAudit>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_StockAuditLst = dbExecutor.FetchData<inv_StockAudit>(CommandType.StoredProcedure, "inv_StockAudit_GetDynamic", colparameters);
				return inv_StockAuditLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_StockAudit> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StockAudit> inv_StockAuditLst = new List<inv_StockAudit>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_StockAuditLst = dbExecutor.FetchDataRef<inv_StockAudit>(CommandType.StoredProcedure, "inv_StockAudit_GetPaged", colparameters, ref rows);
				return inv_StockAuditLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_StockAudit _inv_StockAudit,string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@Id", _inv_StockAudit.Id, DbType.String, ParameterDirection.Input),
				new Parameters("@AuditDate", _inv_StockAudit.AuditDate, DbType.Date, ParameterDirection.Input),
				new Parameters("@AuditedStoreId", _inv_StockAudit.AuditedStoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@AuditedByUserId", _inv_StockAudit.AuditedByUserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Remarks", _inv_StockAudit.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@CreatorId", _inv_StockAudit.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _inv_StockAudit.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@TransactionType ", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "inv_StockAudit_Post", colparameters, true);
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
