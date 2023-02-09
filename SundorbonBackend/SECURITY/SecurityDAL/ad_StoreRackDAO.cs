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
	public class ad_StoreRackDAO : IDisposable
	{
		private static volatile ad_StoreRackDAO instance;
		private static readonly object lockObj = new object();
		public static ad_StoreRackDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_StoreRackDAO();
			}
			return instance;
		}
		public static ad_StoreRackDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_StoreRackDAO();
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

		public ad_StoreRackDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_StoreRack> GetByStoreId(Int32? id = null)
		{
			try
			{
				List<ad_StoreRack> ad_StoreRackLst = new List<ad_StoreRack>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_StoreRackLst = dbExecutor.FetchData<ad_StoreRack>(CommandType.StoredProcedure, "ad_StoreRack_GetAll_By_Store_Id", colparameters);
				return ad_StoreRackLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_StoreRack> GetALL()
		{
			try
			{
				List<ad_StoreRack> ad_StoreRackLst = new List<ad_StoreRack>();
				
				ad_StoreRackLst = dbExecutor.FetchData<ad_StoreRack>(CommandType.StoredProcedure, "ad_StoreRack_GetAll");
				return ad_StoreRackLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_StoreRack> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_StoreRack> ad_StoreRackLst = new List<ad_StoreRack>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_StoreRackLst = dbExecutor.FetchData<ad_StoreRack>(CommandType.StoredProcedure, "ad_StoreRack_GetDynamic", colparameters);
				return ad_StoreRackLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_StoreRack> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_StoreRack> ad_StoreRackLst = new List<ad_StoreRack>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_StoreRackLst = dbExecutor.FetchDataRef<ad_StoreRack>(CommandType.StoredProcedure, "ad_StoreRack_GetPaged", colparameters, ref rows);
				return ad_StoreRackLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_StoreRack _ad_StoreRack)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[6]{
				new Parameters("@Id", _ad_StoreRack.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@StoreId", _ad_StoreRack.StoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RackDescription", _ad_StoreRack.RackDescription, DbType.String, ParameterDirection.Input),
				new Parameters("@IsActive", _ad_StoreRack.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_StoreRack.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_StoreRack.UpdatorId, DbType.Int32, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_StoreRack_Post", colparameters, true);
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
