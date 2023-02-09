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
	public class s_RoleDAO : IDisposable
	{
		private static volatile s_RoleDAO instance;
		private static readonly object lockObj = new object();
		public static s_RoleDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new s_RoleDAO();
			}
			return instance;
		}
		public static s_RoleDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new s_RoleDAO();
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

		public s_RoleDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<s_Role> Get(Int32? roleId = null)
		{
			try
			{
				List<s_Role> s_RoleLst = new List<s_Role>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramRoleId", roleId, DbType.Int32, ParameterDirection.Input)
				};
				s_RoleLst = dbExecutor.FetchData<s_Role>(CommandType.StoredProcedure, "wsp_s_Role_Get", colparameters);
				return s_RoleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<s_Role> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<s_Role> s_RoleLst = new List<s_Role>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				s_RoleLst = dbExecutor.FetchData<s_Role>(CommandType.StoredProcedure, "wsp_s_Role_GetDynamic", colparameters);
				return s_RoleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<s_Role> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<s_Role> s_RoleLst = new List<s_Role>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				s_RoleLst = dbExecutor.FetchDataRef<s_Role>(CommandType.StoredProcedure, "s_Role_GetPaged", colparameters, ref rows);
				return s_RoleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(s_Role _s_Role, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramRoleId", _s_Role.RoleId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRoleName", _s_Role.RoleName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramIsActive", _s_Role.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramIsSuperAdmin", _s_Role.IsSuperAdmin, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramIsCheckoutOperator", _s_Role.IsCheckoutOperator, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _s_Role.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _s_Role.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _s_Role.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _s_Role.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_s_Role_Post", colparameters, true);
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
