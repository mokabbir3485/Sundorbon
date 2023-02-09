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
	public class ad_RecordSerialDAO : IDisposable
	{
		private static volatile ad_RecordSerialDAO instance;
		private static readonly object lockObj = new object();
		public static ad_RecordSerialDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_RecordSerialDAO();
			}
			return instance;
		}
		public static ad_RecordSerialDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_RecordSerialDAO();
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

		public ad_RecordSerialDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_RecordSerial> Get(Int32? id = null)
		{
			try
			{
				List<ad_RecordSerial> ad_RecordSerialLst = new List<ad_RecordSerial>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_RecordSerialLst = dbExecutor.FetchData<ad_RecordSerial>(CommandType.StoredProcedure, "wsp_ad_RecordSerial_Get", colparameters);
				return ad_RecordSerialLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_RecordSerial> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_RecordSerial> ad_RecordSerialLst = new List<ad_RecordSerial>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_RecordSerialLst = dbExecutor.FetchData<ad_RecordSerial>(CommandType.StoredProcedure, "wsp_ad_RecordSerial_GetDynamic", colparameters);
				return ad_RecordSerialLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_RecordSerial> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_RecordSerial> ad_RecordSerialLst = new List<ad_RecordSerial>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_RecordSerialLst = dbExecutor.FetchDataRef<ad_RecordSerial>(CommandType.StoredProcedure, "ad_RecordSerial_GetPaged", colparameters, ref rows);
				return ad_RecordSerialLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_RecordSerial _ad_RecordSerial, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[6]{
				new Parameters("@paramId", _ad_RecordSerial.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCounterId", _ad_RecordSerial.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramPrefix", _ad_RecordSerial.Prefix, DbType., ParameterDirection.Input),
				new Parameters("@paramMaxSlNo", _ad_RecordSerial.MaxSlNo, DbType., ParameterDirection.Input),
				new Parameters("@paramTableName", _ad_RecordSerial.TableName, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_RecordSerial_Post", colparameters, true);
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
