using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using DbExecutor;
using SecurityEntity;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
	public class ad_ModelDAO : IDisposable
	{
		private static volatile ad_ModelDAO instance;
		private static readonly object lockObj = new object();
		public static ad_ModelDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_ModelDAO();
			}
			return instance;
		}
		public static ad_ModelDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_ModelDAO();
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

		public ad_ModelDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		//public List<ad_Model> Get(Int32? id = null)
		//{
		//	try
		//	{
		//		List<ad_Model> ad_ModelLst = new List<ad_Model>();
		//		Parameters[] colparameters = new Parameters[1]{
		//		new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
		//		};
		//		ad_ModelLst = dbExecutor.FetchData<ad_Model>(CommandType.StoredProcedure, "ad_Model_Get", colparameters);
		//		return ad_ModelLst;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}


		public List<ad_Model> GetAll()
		{
			try
			{
				var ad_ModelList = new List<ad_Model>();
				ad_ModelList =
					dbExecutor.FetchData<ad_Model>(CommandType.StoredProcedure, "ad_Model_GetAll");
				return ad_ModelList;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Model> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Model> ad_ModelLst = new List<ad_Model>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_ModelLst = dbExecutor.FetchData<ad_Model>(CommandType.StoredProcedure, "ad_Model_GetDynamic", colparameters);
				return ad_ModelLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Model> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Model> ad_ModelLst = new List<ad_Model>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_ModelLst = dbExecutor.FetchDataRef<ad_Model>(CommandType.StoredProcedure, "ad_Model_GetPaged", colparameters, ref rows);
				return ad_ModelLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Add(ad_Model _ad_Model)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@Id", _ad_Model.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Name", _ad_Model.Name, DbType.String, ParameterDirection.Input),
				new Parameters("@IsActive", _ad_Model.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_Model.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_Model.UpdatorId, DbType.Int32, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Model_Post", colparameters, true);
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
