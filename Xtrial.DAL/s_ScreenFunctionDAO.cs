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
	public class s_ScreenFunctionDAO : IDisposable
	{
		private static volatile s_ScreenFunctionDAO instance;
		private static readonly object lockObj = new object();
		public static s_ScreenFunctionDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new s_ScreenFunctionDAO();
			}
			return instance;
		}
		public static s_ScreenFunctionDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new s_ScreenFunctionDAO();
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

		public s_ScreenFunctionDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<s_ScreenFunction> Get(Int32? functionId = null)
		{
			try
			{
				List<s_ScreenFunction> s_ScreenFunctionLst = new List<s_ScreenFunction>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramFunctionId", functionId, DbType.Int32, ParameterDirection.Input)
				};
				s_ScreenFunctionLst = dbExecutor.FetchData<s_ScreenFunction>(CommandType.StoredProcedure, "wsp_s_ScreenFunction_Get", colparameters);
				return s_ScreenFunctionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<s_ScreenFunction> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<s_ScreenFunction> s_ScreenFunctionLst = new List<s_ScreenFunction>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				s_ScreenFunctionLst = dbExecutor.FetchData<s_ScreenFunction>(CommandType.StoredProcedure, "wsp_s_ScreenFunction_GetDynamic", colparameters);
				return s_ScreenFunctionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<s_ScreenFunction> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<s_ScreenFunction> s_ScreenFunctionLst = new List<s_ScreenFunction>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				s_ScreenFunctionLst = dbExecutor.FetchDataRef<s_ScreenFunction>(CommandType.StoredProcedure, "s_ScreenFunction_GetPaged", colparameters, ref rows);
				return s_ScreenFunctionLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(s_ScreenFunction _s_ScreenFunction, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[3]{
				new Parameters("@paramFunctionId", _s_ScreenFunction.FunctionId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramFunctionName", _s_ScreenFunction.FunctionName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_s_ScreenFunction_Post", colparameters, true);
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
