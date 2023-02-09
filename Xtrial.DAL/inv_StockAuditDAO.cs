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
	public class inv_StockAuditDAO : IDisposable
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

		public List<inv_StockAudit> Get(Int32? id = null)
		{
			try
			{
				List<inv_StockAudit> inv_StockAuditLst = new List<inv_StockAudit>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_StockAuditLst = dbExecutor.FetchData<inv_StockAudit>(CommandType.StoredProcedure, "wsp_inv_StockAudit_Get", colparameters);
				return inv_StockAuditLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_StockAudit> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_StockAudit> inv_StockAuditLst = new List<inv_StockAudit>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_StockAuditLst = dbExecutor.FetchData<inv_StockAudit>(CommandType.StoredProcedure, "wsp_inv_StockAudit_GetDynamic", colparameters);
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
		public string Post(inv_StockAudit _inv_StockAudit, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramId", _inv_StockAudit.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramAuditDate", _inv_StockAudit.AuditDate, DbType., ParameterDirection.Input),
				new Parameters("@paramAuditedStoreId", _inv_StockAudit.AuditedStoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramAuditedByUserId", _inv_StockAudit.AuditedByUserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRemarks", _inv_StockAudit.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramCreatorId", _inv_StockAudit.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _inv_StockAudit.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _inv_StockAudit.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _inv_StockAudit.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_StockAudit_Post", colparameters, true);
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
