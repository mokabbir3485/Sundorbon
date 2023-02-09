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
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_RecordSerialLst = dbExecutor.FetchData<ad_RecordSerial>(CommandType.StoredProcedure, "ad_RecordSerial_Get", colparameters);
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
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_RecordSerialLst = dbExecutor.FetchData<ad_RecordSerial>(CommandType.StoredProcedure, "ad_RecordSerial_GetDynamic", colparameters);
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
		public int Post(ad_RecordSerial _ad_RecordSerial)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[7]{
				new Parameters("@Id", _ad_RecordSerial.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CounterId", _ad_RecordSerial.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Prefix", _ad_RecordSerial.Prefix, DbType.String, ParameterDirection.Input),
				new Parameters("@MaxSlNo", _ad_RecordSerial.MaxSlNo, DbType.String, ParameterDirection.Input),
				new Parameters("@TableName", _ad_RecordSerial.TableName, DbType.String, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_RecordSerial.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_RecordSerial.UpdatorId, DbType.Int32, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_RecordSerial_Post", colparameters, true);
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
