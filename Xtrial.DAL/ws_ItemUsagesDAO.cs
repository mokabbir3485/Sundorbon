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
	public class ws_ItemUsagesDAO : IDisposable
	{
		private static volatile ws_ItemUsagesDAO instance;
		private static readonly object lockObj = new object();
		public static ws_ItemUsagesDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_ItemUsagesDAO();
			}
			return instance;
		}
		public static ws_ItemUsagesDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_ItemUsagesDAO();
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

		public ws_ItemUsagesDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_ItemUsages> Get(string? number = null)
		{
			try
			{
				List<ws_ItemUsages> ws_ItemUsagesLst = new List<ws_ItemUsages>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramNumber", number, DbType.string, ParameterDirection.Input)
				};
				ws_ItemUsagesLst = dbExecutor.FetchData<ws_ItemUsages>(CommandType.StoredProcedure, "wsp_ws_ItemUsages_Get", colparameters);
				return ws_ItemUsagesLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_ItemUsages> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_ItemUsages> ws_ItemUsagesLst = new List<ws_ItemUsages>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_ItemUsagesLst = dbExecutor.FetchData<ws_ItemUsages>(CommandType.StoredProcedure, "wsp_ws_ItemUsages_GetDynamic", colparameters);
				return ws_ItemUsagesLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_ItemUsages> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_ItemUsages> ws_ItemUsagesLst = new List<ws_ItemUsages>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_ItemUsagesLst = dbExecutor.FetchDataRef<ws_ItemUsages>(CommandType.StoredProcedure, "ws_ItemUsages_GetPaged", colparameters, ref rows);
				return ws_ItemUsagesLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_ItemUsages _ws_ItemUsages, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[11]{
				new Parameters("@paramNumber", _ws_ItemUsages.Number, DbType., ParameterDirection.Input),
				new Parameters("@paramUsagesDate", _ws_ItemUsages.UsagesDate, DbType., ParameterDirection.Input),
				new Parameters("@paramUsagedByEmployeeId", _ws_ItemUsages.UsagedByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramPurposeId", _ws_ItemUsages.PurposeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramVechileId", _ws_ItemUsages.VechileId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCounterId", _ws_ItemUsages.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ws_ItemUsages.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _ws_ItemUsages.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ws_ItemUsages.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ws_ItemUsages.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_ItemUsages_Post", colparameters, true);
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
