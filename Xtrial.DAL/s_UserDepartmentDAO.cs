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
	public class s_UserDepartmentDAO : IDisposable
	{
		private static volatile s_UserDepartmentDAO instance;
		private static readonly object lockObj = new object();
		public static s_UserDepartmentDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new s_UserDepartmentDAO();
			}
			return instance;
		}
		public static s_UserDepartmentDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new s_UserDepartmentDAO();
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

		public s_UserDepartmentDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<s_UserDepartment> Get(Int32? userDepartmentId = null)
		{
			try
			{
				List<s_UserDepartment> s_UserDepartmentLst = new List<s_UserDepartment>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramUserDepartmentId", userDepartmentId, DbType.Int32, ParameterDirection.Input)
				};
				s_UserDepartmentLst = dbExecutor.FetchData<s_UserDepartment>(CommandType.StoredProcedure, "wsp_s_UserDepartment_Get", colparameters);
				return s_UserDepartmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<s_UserDepartment> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<s_UserDepartment> s_UserDepartmentLst = new List<s_UserDepartment>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				s_UserDepartmentLst = dbExecutor.FetchData<s_UserDepartment>(CommandType.StoredProcedure, "wsp_s_UserDepartment_GetDynamic", colparameters);
				return s_UserDepartmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<s_UserDepartment> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<s_UserDepartment> s_UserDepartmentLst = new List<s_UserDepartment>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				s_UserDepartmentLst = dbExecutor.FetchDataRef<s_UserDepartment>(CommandType.StoredProcedure, "s_UserDepartment_GetPaged", colparameters, ref rows);
				return s_UserDepartmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(s_UserDepartment _s_UserDepartment, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[4]{
				new Parameters("@paramUserDepartmentId", _s_UserDepartment.UserDepartmentId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUserId", _s_UserDepartment.UserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDepartmentId", _s_UserDepartment.DepartmentId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_s_UserDepartment_Post", colparameters, true);
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
