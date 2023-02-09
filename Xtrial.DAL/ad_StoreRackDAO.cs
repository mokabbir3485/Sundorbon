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

		public List<ad_StoreRack> Get(Int32? id = null)
		{
			try
			{
				List<ad_StoreRack> ad_StoreRackLst = new List<ad_StoreRack>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_StoreRackLst = dbExecutor.FetchData<ad_StoreRack>(CommandType.StoredProcedure, "wsp_ad_StoreRack_Get", colparameters);
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
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_StoreRackLst = dbExecutor.FetchData<ad_StoreRack>(CommandType.StoredProcedure, "wsp_ad_StoreRack_GetDynamic", colparameters);
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
		public string Post(ad_StoreRack _ad_StoreRack, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[9]{
				new Parameters("@paramId", _ad_StoreRack.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramStoreId", _ad_StoreRack.StoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRackDescription", _ad_StoreRack.RackDescription, DbType., ParameterDirection.Input),
				new Parameters("@paramIsActive", _ad_StoreRack.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ad_StoreRack.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _ad_StoreRack.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ad_StoreRack.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ad_StoreRack.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_StoreRack_Post", colparameters, true);
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
