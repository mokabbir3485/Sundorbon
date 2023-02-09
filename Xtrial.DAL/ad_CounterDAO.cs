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
	public class ad_CounterDAO : IDisposable
	{
		private static volatile ad_CounterDAO instance;
		private static readonly object lockObj = new object();
		public static ad_CounterDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_CounterDAO();
			}
			return instance;
		}
		public static ad_CounterDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_CounterDAO();
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

		public ad_CounterDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_Counter> Get(Int32? id = null)
		{
			try
			{
				List<ad_Counter> ad_CounterLst = new List<ad_Counter>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_CounterLst = dbExecutor.FetchData<ad_Counter>(CommandType.StoredProcedure, "wsp_ad_Counter_Get", colparameters);
				return ad_CounterLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Counter> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Counter> ad_CounterLst = new List<ad_Counter>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_CounterLst = dbExecutor.FetchData<ad_Counter>(CommandType.StoredProcedure, "wsp_ad_Counter_GetDynamic", colparameters);
				return ad_CounterLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Counter> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Counter> ad_CounterLst = new List<ad_Counter>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_CounterLst = dbExecutor.FetchDataRef<ad_Counter>(CommandType.StoredProcedure, "ad_Counter_GetPaged", colparameters, ref rows);
				return ad_CounterLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_Counter _ad_Counter, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[7]{
				new Parameters("@paramId", _ad_Counter.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCounterName", _ad_Counter.CounterName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramDepartmentId", _ad_Counter.DepartmentId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIPAddress", _ad_Counter.IPAddress, DbType.String, ParameterDirection.Input),
				new Parameters("@paramShortCode", _ad_Counter.ShortCode, DbType.String, ParameterDirection.Input),
				new Parameters("@paramIsActive", _ad_Counter.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_Counter_Post", colparameters, true);
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
