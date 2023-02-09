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
	public class ad_ApprovalGivenOnDAO : IDisposable
	{
		private static volatile ad_ApprovalGivenOnDAO instance;
		private static readonly object lockObj = new object();
		public static ad_ApprovalGivenOnDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_ApprovalGivenOnDAO();
			}
			return instance;
		}
		public static ad_ApprovalGivenOnDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_ApprovalGivenOnDAO();
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

		public ad_ApprovalGivenOnDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_ApprovalGivenOn> Get(Int32? id = null)
		{
			try
			{
				List<ad_ApprovalGivenOn> ad_ApprovalGivenOnLst = new List<ad_ApprovalGivenOn>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_ApprovalGivenOnLst = dbExecutor.FetchData<ad_ApprovalGivenOn>(CommandType.StoredProcedure, "ad_ApprovalGivenOn_Get", colparameters);
				return ad_ApprovalGivenOnLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_ApprovalGivenOn> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_ApprovalGivenOn> ad_ApprovalGivenOnLst = new List<ad_ApprovalGivenOn>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_ApprovalGivenOnLst = dbExecutor.FetchData<ad_ApprovalGivenOn>(CommandType.StoredProcedure, "ad_ApprovalGivenOn_GetDynamic", colparameters);
				return ad_ApprovalGivenOnLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_ApprovalGivenOn> GetAll()
		{
			try
			{
				var ad_DepertmentLst = new List<ad_ApprovalGivenOn>();
				ad_DepertmentLst =
					dbExecutor.FetchData<ad_ApprovalGivenOn>(CommandType.StoredProcedure, "ad_ApprovalGivenOn_GetAll");
				return ad_DepertmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_ApprovalGivenOn> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_ApprovalGivenOn> ad_ApprovalGivenOnLst = new List<ad_ApprovalGivenOn>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_ApprovalGivenOnLst = dbExecutor.FetchDataRef<ad_ApprovalGivenOn>(CommandType.StoredProcedure, "ad_ApprovalGivenOn_GetPaged", colparameters, ref rows);
				return ad_ApprovalGivenOnLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_ApprovalGivenOn _ad_ApprovalGivenOn)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@Id", _ad_ApprovalGivenOn.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ApprovalGivenOn", _ad_ApprovalGivenOn.ApprovalGivenOn, DbType.String, ParameterDirection.Input),
				new Parameters("@IsActive", _ad_ApprovalGivenOn.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_ApprovalGivenOn.CreatorId, DbType.String, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_ApprovalGivenOn.UpdatorId, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_ApprovalGivenOn_Post", colparameters, true);
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
