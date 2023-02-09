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
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_BranchLst = dbExecutor.FetchData<ad_Branch>(CommandType.StoredProcedure, "wsp_ad_Branch_Get", colparameters);
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
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_BranchLst = dbExecutor.FetchData<ad_Branch>(CommandType.StoredProcedure, "wsp_ad_Branch_GetDynamic", colparameters);
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
		public string Post(ad_Branch _ad_Branch, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[6]{
				new Parameters("@paramId", _ad_Branch.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramMotherCompanyId", _ad_Branch.MotherCompanyId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramBranchName", _ad_Branch.BranchName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramAddress1", _ad_Branch.Address1, DbType.String, ParameterDirection.Input),
				new Parameters("@paramAddress2", _ad_Branch.Address2, DbType.String, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_Branch_Post", colparameters, true);
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
