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
	public class ad_IssueTypeDAO : IDisposable
	{
		private static volatile ad_IssueTypeDAO instance;
		private static readonly object lockObj = new object();
		public static ad_IssueTypeDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_IssueTypeDAO();
			}
			return instance;
		}
		public static ad_IssueTypeDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_IssueTypeDAO();
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

		public ad_IssueTypeDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_IssueType> Get()
		{
			try
			{
				List<ad_IssueType> ad_IssueTypeLst = new List<ad_IssueType>();
			
				ad_IssueTypeLst = dbExecutor.FetchData<ad_IssueType>(CommandType.StoredProcedure, "ad_IssueType_GetAll");
				return ad_IssueTypeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_IssueType> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_IssueType> ad_IssueTypeLst = new List<ad_IssueType>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_IssueTypeLst = dbExecutor.FetchData<ad_IssueType>(CommandType.StoredProcedure, "ad_IssueType_GetDynamic", colparameters);
				return ad_IssueTypeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_IssueType> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_IssueType> ad_IssueTypeLst = new List<ad_IssueType>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_IssueTypeLst = dbExecutor.FetchDataRef<ad_IssueType>(CommandType.StoredProcedure, "ad_IssueType_GetPaged", colparameters, ref rows);
				return ad_IssueTypeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_IssueType _ad_IssueType)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@Id", _ad_IssueType.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@IssueType", _ad_IssueType.IssueType, DbType.String, ParameterDirection.Input),
				new Parameters("@IsActive", _ad_IssueType.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_IssueType.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_IssueType.UpdatorId, DbType.Int32, ParameterDirection.Input),
				
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_IssueType_Post", colparameters, true);
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
