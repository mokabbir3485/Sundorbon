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
	public class ad_DepartmentDAO : IDisposable
	{
		private static volatile ad_DepartmentDAO instance;
		private static readonly object lockObj = new object();
		public static ad_DepartmentDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_DepartmentDAO();
			}
			return instance;
		}
		public static ad_DepartmentDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_DepartmentDAO();
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

		public ad_DepartmentDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_Department> Get(Int32? id = null)
		{
			try
			{
				List<ad_Department> ad_DepartmentLst = new List<ad_Department>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_DepartmentLst = dbExecutor.FetchData<ad_Department>(CommandType.StoredProcedure, "wsp_ad_Department_Get", colparameters);
				return ad_DepartmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Department> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Department> ad_DepartmentLst = new List<ad_Department>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_DepartmentLst = dbExecutor.FetchData<ad_Department>(CommandType.StoredProcedure, "wsp_ad_Department_GetDynamic", colparameters);
				return ad_DepartmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Department> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Department> ad_DepartmentLst = new List<ad_Department>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_DepartmentLst = dbExecutor.FetchDataRef<ad_Department>(CommandType.StoredProcedure, "ad_Department_GetPaged", colparameters, ref rows);
				return ad_DepartmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_Department _ad_Department, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[6]{
				new Parameters("@paramId", _ad_Department.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramBranchId", _ad_Department.BranchId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDepartmentName", _ad_Department.DepartmentName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramAddress1", _ad_Department.Address1, DbType.String, ParameterDirection.Input),
				new Parameters("@paramAddress2", _ad_Department.Address2, DbType.String, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_Department_Post", colparameters, true);
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
