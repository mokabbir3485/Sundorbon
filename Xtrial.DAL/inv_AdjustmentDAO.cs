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
	public class inv_AdjustmentDAO : IDisposable
	{
		private static volatile inv_AdjustmentDAO instance;
		private static readonly object lockObj = new object();
		public static inv_AdjustmentDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_AdjustmentDAO();
			}
			return instance;
		}
		public static inv_AdjustmentDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_AdjustmentDAO();
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

		public inv_AdjustmentDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_Adjustment> Get(string? number = null)
		{
			try
			{
				List<inv_Adjustment> inv_AdjustmentLst = new List<inv_Adjustment>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramNumber", number, DbType.string, ParameterDirection.Input)
				};
				inv_AdjustmentLst = dbExecutor.FetchData<inv_Adjustment>(CommandType.StoredProcedure, "wsp_inv_Adjustment_Get", colparameters);
				return inv_AdjustmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_Adjustment> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_Adjustment> inv_AdjustmentLst = new List<inv_Adjustment>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_AdjustmentLst = dbExecutor.FetchData<inv_Adjustment>(CommandType.StoredProcedure, "wsp_inv_Adjustment_GetDynamic", colparameters);
				return inv_AdjustmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_Adjustment> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_Adjustment> inv_AdjustmentLst = new List<inv_Adjustment>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_AdjustmentLst = dbExecutor.FetchDataRef<inv_Adjustment>(CommandType.StoredProcedure, "inv_Adjustment_GetPaged", colparameters, ref rows);
				return inv_AdjustmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_Adjustment _inv_Adjustment, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@paramNumber", _inv_Adjustment.Number, DbType., ParameterDirection.Input),
				new Parameters("@paramAdjustmentDate", _inv_Adjustment.AdjustmentDate, DbType., ParameterDirection.Input),
				new Parameters("@paramAdjustedByUserId", _inv_Adjustment.AdjustedByUserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramAdjustedReason", _inv_Adjustment.AdjustedReason, DbType., ParameterDirection.Input),
				new Parameters("@paramCounterId", _inv_Adjustment.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _inv_Adjustment.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _inv_Adjustment.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _inv_Adjustment.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _inv_Adjustment.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_Adjustment_Post", colparameters, true);
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
