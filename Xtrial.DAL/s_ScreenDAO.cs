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
	public class s_ScreenDAO : IDisposable
	{
		private static volatile s_ScreenDAO instance;
		private static readonly object lockObj = new object();
		public static s_ScreenDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new s_ScreenDAO();
			}
			return instance;
		}
		public static s_ScreenDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new s_ScreenDAO();
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

		public s_ScreenDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<s_Screen> Get(Int32? screenId = null)
		{
			try
			{
				List<s_Screen> s_ScreenLst = new List<s_Screen>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramScreenId", screenId, DbType.Int32, ParameterDirection.Input)
				};
				s_ScreenLst = dbExecutor.FetchData<s_Screen>(CommandType.StoredProcedure, "wsp_s_Screen_Get", colparameters);
				return s_ScreenLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<s_Screen> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<s_Screen> s_ScreenLst = new List<s_Screen>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				s_ScreenLst = dbExecutor.FetchData<s_Screen>(CommandType.StoredProcedure, "wsp_s_Screen_GetDynamic", colparameters);
				return s_ScreenLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<s_Screen> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<s_Screen> s_ScreenLst = new List<s_Screen>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				s_ScreenLst = dbExecutor.FetchDataRef<s_Screen>(CommandType.StoredProcedure, "s_Screen_GetPaged", colparameters, ref rows);
				return s_ScreenLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(s_Screen _s_Screen, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramScreenId", _s_Screen.ScreenId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramModuleId", _s_Screen.ModuleId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramScreenName", _s_Screen.ScreenName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramDescription", _s_Screen.Description, DbType.String, ParameterDirection.Input),
				new Parameters("@paramScreenUrl", _s_Screen.ScreenUrl, DbType.String, ParameterDirection.Input),
				new Parameters("@paramImageUrl", _s_Screen.ImageUrl, DbType.String, ParameterDirection.Input),
				new Parameters("@paramIsPage", _s_Screen.IsPage, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramSorting", _s_Screen.Sorting, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramMainTableName", _s_Screen.MainTableName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_s_Screen_Post", colparameters, true);
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
