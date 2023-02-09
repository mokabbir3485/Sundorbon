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
	public class inv_AdjustmentDetailsDAO : IDisposable
	{
		private static volatile inv_AdjustmentDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static inv_AdjustmentDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_AdjustmentDetailsDAO();
			}
			return instance;
		}
		public static inv_AdjustmentDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_AdjustmentDetailsDAO();
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

		public inv_AdjustmentDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_AdjustmentDetails> Get(Int32? id = null)
		{
			try
			{
				List<inv_AdjustmentDetails> inv_AdjustmentDetailsLst = new List<inv_AdjustmentDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_AdjustmentDetailsLst = dbExecutor.FetchData<inv_AdjustmentDetails>(CommandType.StoredProcedure, "wsp_inv_AdjustmentDetails_Get", colparameters);
				return inv_AdjustmentDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_AdjustmentDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<inv_AdjustmentDetails> inv_AdjustmentDetailsLst = new List<inv_AdjustmentDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_AdjustmentDetailsLst = dbExecutor.FetchData<inv_AdjustmentDetails>(CommandType.StoredProcedure, "wsp_inv_AdjustmentDetails_GetDynamic", colparameters);
				return inv_AdjustmentDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_AdjustmentDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_AdjustmentDetails> inv_AdjustmentDetailsLst = new List<inv_AdjustmentDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_AdjustmentDetailsLst = dbExecutor.FetchDataRef<inv_AdjustmentDetails>(CommandType.StoredProcedure, "inv_AdjustmentDetails_GetPaged", colparameters, ref rows);
				return inv_AdjustmentDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(inv_AdjustmentDetails _inv_AdjustmentDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@paramId", _inv_AdjustmentDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramRackId", _inv_AdjustmentDetails.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramItemId", _inv_AdjustmentDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIsIncreased", _inv_AdjustmentDetails.IsIncreased, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramAdjustedQty", _inv_AdjustmentDetails.AdjustedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramAdjstedUnitPrice", _inv_AdjustmentDetails.AdjstedUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramRemarks", _inv_AdjustmentDetails.Remarks, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_inv_AdjustmentDetails_Post", colparameters, true);
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
