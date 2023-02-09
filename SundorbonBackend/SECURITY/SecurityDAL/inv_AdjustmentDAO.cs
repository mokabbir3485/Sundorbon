using DbExecutor;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
    public class inv_AdjustmentDAO
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

		public List<inv_Adjustment> Get(String number = null)
		{
			try
			{
				List<inv_Adjustment> inv_AdjustmentLst = new List<inv_Adjustment>();
				Parameters[] colparameters = new Parameters[]{
				new Parameters("@Number", number, DbType.String, ParameterDirection.Input)
				};
				inv_AdjustmentLst = dbExecutor.FetchData<inv_Adjustment>(CommandType.StoredProcedure, "inv_Adjustment_Get", colparameters);
				return inv_AdjustmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_Adjustment> GetALL()
		{
			try
			{
				List<inv_Adjustment> inv_AdjustmentLst = new List<inv_Adjustment>();
				
				inv_AdjustmentLst = dbExecutor.FetchData<inv_Adjustment>(CommandType.StoredProcedure, "inv_Adjustment_GetAll");
				return inv_AdjustmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_Adjustment> GetDynamic(string whereCondition, string orderByExpression)
		{
			try
			{
				List<inv_Adjustment> inv_AdjustmentLst = new List<inv_Adjustment>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_AdjustmentLst = dbExecutor.FetchData<inv_Adjustment>(CommandType.StoredProcedure, "inv_Adjustment_GetDynamic", colparameters);
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
		public string Post(inv_Adjustment _inv_Adjustment , string transactiontionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@Number", _inv_Adjustment.Number, DbType.String, ParameterDirection.Input),
				new Parameters("@AdjustmentDate", _inv_Adjustment.AdjustmentDate, DbType.Date, ParameterDirection.Input),
				new Parameters("@AdjustedByUserId", _inv_Adjustment.AdjustedByUserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@AdjustedReason", _inv_Adjustment.AdjustedReason, DbType.String, ParameterDirection.Input),
				new Parameters("@CounterId", _inv_Adjustment.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _inv_Adjustment.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _inv_Adjustment.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@transactiontionType", transactiontionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "inv_Adjustment_Post", colparameters, true);
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
