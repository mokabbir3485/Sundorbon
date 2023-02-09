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
	public class s_ScreenDetailDAO : IDisposable
	{
		private static volatile s_ScreenDetailDAO instance;
		private static readonly object lockObj = new object();
		public static s_ScreenDetailDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new s_ScreenDetailDAO();
			}
			return instance;
		}
		public static s_ScreenDetailDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new s_ScreenDetailDAO();
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

		public s_ScreenDetailDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<s_ScreenDetail> Get(Int32? screenDetailId = null)
		{
			try
			{
				List<s_ScreenDetail> s_ScreenDetailLst = new List<s_ScreenDetail>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramScreenDetailId", screenDetailId, DbType.Int32, ParameterDirection.Input)
				};
				s_ScreenDetailLst = dbExecutor.FetchData<s_ScreenDetail>(CommandType.StoredProcedure, "wsp_s_ScreenDetail_Get", colparameters);
				return s_ScreenDetailLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<s_ScreenDetail> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<s_ScreenDetail> s_ScreenDetailLst = new List<s_ScreenDetail>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				s_ScreenDetailLst = dbExecutor.FetchData<s_ScreenDetail>(CommandType.StoredProcedure, "wsp_s_ScreenDetail_GetDynamic", colparameters);
				return s_ScreenDetailLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<s_ScreenDetail> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<s_ScreenDetail> s_ScreenDetailLst = new List<s_ScreenDetail>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				s_ScreenDetailLst = dbExecutor.FetchDataRef<s_ScreenDetail>(CommandType.StoredProcedure, "s_ScreenDetail_GetPaged", colparameters, ref rows);
				return s_ScreenDetailLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(s_ScreenDetail _s_ScreenDetail, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[4]{
				new Parameters("@paramScreenDetailId", _s_ScreenDetail.ScreenDetailId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramScreenId", _s_ScreenDetail.ScreenId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramFunctionId", _s_ScreenDetail.FunctionId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_s_ScreenDetail_Post", colparameters, true);
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
