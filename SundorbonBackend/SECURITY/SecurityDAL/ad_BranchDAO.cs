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
	public class ad_BranchDAO : IDisposable
	{
		private static volatile ad_BranchDAO instance;
		private static readonly object lockObj = new object();
		public static ad_BranchDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_BranchDAO();
			}
			return instance;
		}
		public static ad_BranchDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_BranchDAO();
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

		public ad_BranchDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_Branch> Get(Int32? id = null)
		{
			try
			{
				List<ad_Branch> ad_BranchLst = new List<ad_Branch>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_BranchLst = dbExecutor.FetchData<ad_Branch>(CommandType.StoredProcedure, "ad_Branch_Get", colparameters);
				return ad_BranchLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Branch> GetAll()
		{
			try
			{
				var ad_BranchLst = new List<ad_Branch>();
				ad_BranchLst =
					dbExecutor.FetchData<ad_Branch>(CommandType.StoredProcedure, "ad_Branch_GetAll");
				return ad_BranchLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Branch> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Branch> ad_BranchLst = new List<ad_Branch>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_BranchLst = dbExecutor.FetchData<ad_Branch>(CommandType.StoredProcedure, "ad_Branch_GetDynamic", colparameters);
				return ad_BranchLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Branch> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Branch> ad_BranchLst = new List<ad_Branch>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_BranchLst = dbExecutor.FetchDataRef<ad_Branch>(CommandType.StoredProcedure, "ad_Branch_GetPaged", colparameters, ref rows);
				return ad_BranchLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_Branch _ad_Branch)
		{
			int ret = 1;
			try
			{
				Parameters[] colparameters = new Parameters[7]{
				new Parameters("@Id", _ad_Branch.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@MotherCompanyId", _ad_Branch.MotherCompanyId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@BranchName", _ad_Branch.BranchName, DbType.String, ParameterDirection.Input),
				new Parameters("@Address1", _ad_Branch.Address1, DbType.String, ParameterDirection.Input),
				new Parameters("@Address2", _ad_Branch.Address2, DbType.String, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_Branch.CreatorId, DbType.String, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_Branch.UpdatorId, DbType.String, ParameterDirection.Input),

				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Branch_Post", colparameters, true);
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
