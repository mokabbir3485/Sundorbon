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
	public class ad_RequistionTypeDAO : IDisposable
	{
		private static volatile ad_RequistionTypeDAO instance;
		private static readonly object lockObj = new object();
		public static ad_RequistionTypeDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_RequistionTypeDAO();
			}
			return instance;
		}
		public static ad_RequistionTypeDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_RequistionTypeDAO();
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

		public ad_RequistionTypeDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_RequistionType> Get(Int32? id = null)
		{
			try
			{
				List<ad_RequistionType> ad_RequistionTypeLst = new List<ad_RequistionType>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_RequistionTypeLst = dbExecutor.FetchData<ad_RequistionType>(CommandType.StoredProcedure, "ad_RequistionType_Get", colparameters);
				return ad_RequistionTypeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_RequistionType> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_RequistionType> ad_RequistionTypeLst = new List<ad_RequistionType>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_RequistionTypeLst = dbExecutor.FetchData<ad_RequistionType>(CommandType.StoredProcedure, "ad_RequistionType_GetDynamic", colparameters);
				return ad_RequistionTypeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_RequistionType> GetAll()
		{
			try
			{
				List<ad_RequistionType> ad_RequistionTypeLst = new List<ad_RequistionType>();
			
				ad_RequistionTypeLst = dbExecutor.FetchData<ad_RequistionType>(CommandType.StoredProcedure, "ad_RequistionType_GetAll");
				return ad_RequistionTypeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		
		public List<ad_RequistionType> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_RequistionType> ad_RequistionTypeLst = new List<ad_RequistionType>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_RequistionTypeLst = dbExecutor.FetchDataRef<ad_RequistionType>(CommandType.StoredProcedure, "ad_RequistionType_GetPaged", colparameters, ref rows);
				return ad_RequistionTypeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_RequistionType _ad_RequistionType)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@Id", _ad_RequistionType.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RequistionType", _ad_RequistionType.RequistionType, DbType.String, ParameterDirection.Input),
				new Parameters("@IsActive", _ad_RequistionType.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_RequistionType.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_RequistionType.UpdatorId, DbType.Int32, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_RequistionType_Post", colparameters, true);
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
