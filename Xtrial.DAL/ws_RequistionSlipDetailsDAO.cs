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
	public class ws_RequistionSlipDetailsDAO : IDisposable
	{
		private static volatile ws_RequistionSlipDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static ws_RequistionSlipDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_RequistionSlipDetailsDAO();
			}
			return instance;
		}
		public static ws_RequistionSlipDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_RequistionSlipDetailsDAO();
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

		public ws_RequistionSlipDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_RequistionSlipDetails> Get(Int32? id = null)
		{
			try
			{
				List<ws_RequistionSlipDetails> ws_RequistionSlipDetailsLst = new List<ws_RequistionSlipDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ws_RequistionSlipDetailsLst = dbExecutor.FetchData<ws_RequistionSlipDetails>(CommandType.StoredProcedure, "wsp_ws_RequistionSlipDetails_Get", colparameters);
				return ws_RequistionSlipDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ws_RequistionSlipDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ws_RequistionSlipDetails> ws_RequistionSlipDetailsLst = new List<ws_RequistionSlipDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ws_RequistionSlipDetailsLst = dbExecutor.FetchData<ws_RequistionSlipDetails>(CommandType.StoredProcedure, "wsp_ws_RequistionSlipDetails_GetDynamic", colparameters);
				return ws_RequistionSlipDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ws_RequistionSlipDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_RequistionSlipDetails> ws_RequistionSlipDetailsLst = new List<ws_RequistionSlipDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_RequistionSlipDetailsLst = dbExecutor.FetchDataRef<ws_RequistionSlipDetails>(CommandType.StoredProcedure, "ws_RequistionSlipDetails_GetPaged", colparameters, ref rows);
				return ws_RequistionSlipDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ws_RequistionSlipDetails _ws_RequistionSlipDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@paramId", _ws_RequistionSlipDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRequistionSlipNumber", _ws_RequistionSlipDetails.RequistionSlipNumber, DbType., ParameterDirection.Input),
				new Parameters("@paramItemId", _ws_RequistionSlipDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRequestedQty", _ws_RequistionSlipDetails.RequestedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramDamagedItemQty", _ws_RequistionSlipDetails.DamagedItemQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramRemarks", _ws_RequistionSlipDetails.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramIsVoid", _ws_RequistionSlipDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ws_RequistionSlipDetails_Post", colparameters, true);
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
