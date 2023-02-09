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
	public class ad_StoreDAO : IDisposable
	{
		private static volatile ad_StoreDAO instance;
		private static readonly object lockObj = new object();
		public static ad_StoreDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_StoreDAO();
			}
			return instance;
		}
		public static ad_StoreDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_StoreDAO();
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

		public ad_StoreDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}
		
		public List<ad_Store> GetAll()
		{
			try
			{
				List<ad_Store> ad_StoreLst = new List<ad_Store>();
				
				ad_StoreLst = dbExecutor.FetchData<ad_Store>(CommandType.StoredProcedure, "ad_Store_GetAll");
				return ad_StoreLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_StoreRack> GetAllRack()
		{
			try
			{
				List<ad_StoreRack> ad_StoreLst = new List<ad_StoreRack>();

				ad_StoreLst = dbExecutor.FetchData<ad_StoreRack>(CommandType.StoredProcedure, "ad_StoreRack_GetAll");
				return ad_StoreLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Store> Get(Int32? id = null)
		{
			try
			{
				List<ad_Store> ad_StoreLst = new List<ad_Store>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_StoreLst = dbExecutor.FetchData<ad_Store>(CommandType.StoredProcedure, "ad_Store_Get", colparameters);
				return ad_StoreLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Store> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Store> ad_StoreLst = new List<ad_Store>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_StoreLst = dbExecutor.FetchData<ad_Store>(CommandType.StoredProcedure, "ad_Store_GetDynamic", colparameters);
				return ad_StoreLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Store> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Store> ad_StoreLst = new List<ad_Store>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_StoreLst = dbExecutor.FetchDataRef<ad_Store>(CommandType.StoredProcedure, "ad_Store_GetPaged", colparameters, ref rows);
				return ad_StoreLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_Store _ad_Store)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[7]{
				new Parameters("@Id", _ad_Store.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@StoreName", _ad_Store.StoreName, DbType.String, ParameterDirection.Input),
				new Parameters("@StoreLocation", _ad_Store.StoreLocation, DbType.String, ParameterDirection.Input),
				new Parameters("@IsActive", _ad_Store.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@DepartmentId", _ad_Store.DepartmentId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_Store.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_Store.UpdatorId, DbType.Int32, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Store_Post", colparameters, true);
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
