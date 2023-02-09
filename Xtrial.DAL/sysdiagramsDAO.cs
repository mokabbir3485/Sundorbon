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
	public class sysdiagramsDAO : IDisposable
	{
		private static volatile sysdiagramsDAO instance;
		private static readonly object lockObj = new object();
		public static sysdiagramsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new sysdiagramsDAO();
			}
			return instance;
		}
		public static sysdiagramsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new sysdiagramsDAO();
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

		public sysdiagramsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<sysdiagrams> Get(Int32? diagram_id = null)
		{
			try
			{
				List<sysdiagrams> sysdiagramsLst = new List<sysdiagrams>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramdiagram_id", diagram_id, DbType.Int32, ParameterDirection.Input)
				};
				sysdiagramsLst = dbExecutor.FetchData<sysdiagrams>(CommandType.StoredProcedure, "wsp_sysdiagrams_Get", colparameters);
				return sysdiagramsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<sysdiagrams> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<sysdiagrams> sysdiagramsLst = new List<sysdiagrams>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				sysdiagramsLst = dbExecutor.FetchData<sysdiagrams>(CommandType.StoredProcedure, "wsp_sysdiagrams_GetDynamic", colparameters);
				return sysdiagramsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<sysdiagrams> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<sysdiagrams> sysdiagramsLst = new List<sysdiagrams>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				sysdiagramsLst = dbExecutor.FetchDataRef<sysdiagrams>(CommandType.StoredProcedure, "sysdiagrams_GetPaged", colparameters, ref rows);
				return sysdiagramsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(sysdiagrams _sysdiagrams, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[6]{
				new Parameters("@paramname", _sysdiagrams.name, DbType.String, ParameterDirection.Input),
				new Parameters("@paramprincipal_id", _sysdiagrams.principal_id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramdiagram_id", _sysdiagrams.diagram_id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramversion", _sysdiagrams.version, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramdefinition", _sysdiagrams.definition, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_sysdiagrams_Post", colparameters, true);
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
