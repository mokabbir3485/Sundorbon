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
	public class s_PermissionDetailDAO : IDisposable
	{
		private static volatile s_PermissionDetailDAO instance;
		private static readonly object lockObj = new object();
		public static s_PermissionDetailDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new s_PermissionDetailDAO();
			}
			return instance;
		}
		public static s_PermissionDetailDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new s_PermissionDetailDAO();
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

		public s_PermissionDetailDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<s_PermissionDetail> Get(Int64? permissionDetailId = null)
		{
			try
			{
				List<s_PermissionDetail> s_PermissionDetailLst = new List<s_PermissionDetail>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramPermissionDetailId", permissionDetailId, DbType.Int64, ParameterDirection.Input)
				};
				s_PermissionDetailLst = dbExecutor.FetchData<s_PermissionDetail>(CommandType.StoredProcedure, "wsp_s_PermissionDetail_Get", colparameters);
				return s_PermissionDetailLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<s_PermissionDetail> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<s_PermissionDetail> s_PermissionDetailLst = new List<s_PermissionDetail>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				s_PermissionDetailLst = dbExecutor.FetchData<s_PermissionDetail>(CommandType.StoredProcedure, "wsp_s_PermissionDetail_GetDynamic", colparameters);
				return s_PermissionDetailLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<s_PermissionDetail> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<s_PermissionDetail> s_PermissionDetailLst = new List<s_PermissionDetail>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				s_PermissionDetailLst = dbExecutor.FetchDataRef<s_PermissionDetail>(CommandType.StoredProcedure, "s_PermissionDetail_GetPaged", colparameters, ref rows);
				return s_PermissionDetailLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(s_PermissionDetail _s_PermissionDetail, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@paramPermissionDetailId", _s_PermissionDetail.PermissionDetailId, DbType.Int64, ParameterDirection.Input),
				new Parameters("@paramPermissionId", _s_PermissionDetail.PermissionId, DbType.Int64, ParameterDirection.Input),
				new Parameters("@paramScreenDetailId", _s_PermissionDetail.ScreenDetailId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCanExecute", _s_PermissionDetail.CanExecute, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_s_PermissionDetail_Post", colparameters, true);
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
