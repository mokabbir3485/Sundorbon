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
	public class s_PermissionDAO : IDisposable
	{
		private static volatile s_PermissionDAO instance;
		private static readonly object lockObj = new object();
		public static s_PermissionDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new s_PermissionDAO();
			}
			return instance;
		}
		public static s_PermissionDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new s_PermissionDAO();
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

		public s_PermissionDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<s_Permission> Get(Int64? permissionId = null)
		{
			try
			{
				List<s_Permission> s_PermissionLst = new List<s_Permission>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramPermissionId", permissionId, DbType.Int64, ParameterDirection.Input)
				};
				s_PermissionLst = dbExecutor.FetchData<s_Permission>(CommandType.StoredProcedure, "wsp_s_Permission_Get", colparameters);
				return s_PermissionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<s_Permission> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<s_Permission> s_PermissionLst = new List<s_Permission>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				s_PermissionLst = dbExecutor.FetchData<s_Permission>(CommandType.StoredProcedure, "wsp_s_Permission_GetDynamic", colparameters);
				return s_PermissionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<s_Permission> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<s_Permission> s_PermissionLst = new List<s_Permission>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				s_PermissionLst = dbExecutor.FetchDataRef<s_Permission>(CommandType.StoredProcedure, "s_Permission_GetPaged", colparameters, ref rows);
				return s_PermissionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(s_Permission _s_Permission, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[9]{
				new Parameters("@paramPermissionId", _s_Permission.PermissionId, DbType.Int64, ParameterDirection.Input),
				new Parameters("@paramRoleId", _s_Permission.RoleId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramScreenId", _s_Permission.ScreenId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCanView", _s_Permission.CanView, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _s_Permission.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _s_Permission.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _s_Permission.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _s_Permission.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_s_Permission_Post", colparameters, true);
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
