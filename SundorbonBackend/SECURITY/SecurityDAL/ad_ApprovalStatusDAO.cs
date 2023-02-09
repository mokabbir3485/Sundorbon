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
	public class ad_ApprovalStatusDAO : IDisposable
	{
		private static volatile ad_ApprovalStatusDAO instance;
		private static readonly object lockObj = new object();
		public static ad_ApprovalStatusDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_ApprovalStatusDAO();
			}
			return instance;
		}
		public static ad_ApprovalStatusDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_ApprovalStatusDAO();
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

		public ad_ApprovalStatusDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_ApprovalStatus> Get(Int32? id = null)
		{
			try
			{
				List<ad_ApprovalStatus> ad_ApprovalStatusLst = new List<ad_ApprovalStatus>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_ApprovalStatusLst = dbExecutor.FetchData<ad_ApprovalStatus>(CommandType.StoredProcedure, "wsp_ad_ApprovalStatus_Get", colparameters);
				return ad_ApprovalStatusLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_ApprovalStatus> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_ApprovalStatus> ad_ApprovalStatusLst = new List<ad_ApprovalStatus>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_ApprovalStatusLst = dbExecutor.FetchData<ad_ApprovalStatus>(CommandType.StoredProcedure, "wsp_ad_ApprovalStatus_GetDynamic", colparameters);
				return ad_ApprovalStatusLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_ApprovalStatus> GetAll()
		{
			try
			{
				var ad_DepertmentLst = new List<ad_ApprovalStatus>();
				ad_DepertmentLst =
					dbExecutor.FetchData<ad_ApprovalStatus>(CommandType.StoredProcedure, "ad_ApprovalStatus_GetAll");
				return ad_DepertmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_ApprovalStatus> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_ApprovalStatus> ad_ApprovalStatusLst = new List<ad_ApprovalStatus>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_ApprovalStatusLst = dbExecutor.FetchDataRef<ad_ApprovalStatus>(CommandType.StoredProcedure, "ad_ApprovalStatus_GetPaged", colparameters, ref rows);
				return ad_ApprovalStatusLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_ApprovalStatus _ad_ApprovalStatus)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@Id", _ad_ApprovalStatus.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Status", _ad_ApprovalStatus.Status, DbType.String, ParameterDirection.Input),
				new Parameters("@Isactive", _ad_ApprovalStatus.Isactive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_ApprovalStatus.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_ApprovalStatus.UpdatorId, DbType.Int32, ParameterDirection.Input),
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_ApprovalStatus_Post", colparameters, true);
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
