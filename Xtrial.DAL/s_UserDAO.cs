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
	public class s_UserDAO : IDisposable
	{
		private static volatile s_UserDAO instance;
		private static readonly object lockObj = new object();
		public static s_UserDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new s_UserDAO();
			}
			return instance;
		}
		public static s_UserDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new s_UserDAO();
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

		public s_UserDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<s_User> Get(Int32? userId = null)
		{
			try
			{
				List<s_User> s_UserLst = new List<s_User>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramUserId", userId, DbType.Int32, ParameterDirection.Input)
				};
				s_UserLst = dbExecutor.FetchData<s_User>(CommandType.StoredProcedure, "wsp_s_User_Get", colparameters);
				return s_UserLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<s_User> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<s_User> s_UserLst = new List<s_User>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				s_UserLst = dbExecutor.FetchData<s_User>(CommandType.StoredProcedure, "wsp_s_User_GetDynamic", colparameters);
				return s_UserLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<s_User> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<s_User> s_UserLst = new List<s_User>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				s_UserLst = dbExecutor.FetchDataRef<s_User>(CommandType.StoredProcedure, "s_User_GetPaged", colparameters, ref rows);
				return s_UserLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(s_User _s_User, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[14]{
				new Parameters("@paramUserId", _s_User.UserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramEmployeeId", _s_User.EmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRoleId", _s_User.RoleId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUsername", _s_User.Username, DbType.String, ParameterDirection.Input),
				new Parameters("@paramPassword", _s_User.Password, DbType.String, ParameterDirection.Input),
				new Parameters("@paramIsReqSmsCode", _s_User.IsReqSmsCode, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramSmsMobileNo", _s_User.SmsMobileNo, DbType.String, ParameterDirection.Input),
				new Parameters("@paramAuthorizationPassword", _s_User.AuthorizationPassword, DbType.String, ParameterDirection.Input),
				new Parameters("@paramIsActive", _s_User.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _s_User.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _s_User.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _s_User.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _s_User.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_s_User_Post", colparameters, true);
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
