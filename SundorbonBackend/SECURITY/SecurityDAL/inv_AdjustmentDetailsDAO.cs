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
    public class inv_AdjustmentDetailsDAO
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

		public List<inv_AdjustmentDetails> Get(String number = null)
		{
			try
			{
				List<inv_AdjustmentDetails> inv_AdjustmentDetailsLst = new List<inv_AdjustmentDetails>();
				Parameters[] colparameters = new Parameters[]{
				new Parameters("@Number", number, DbType.String, ParameterDirection.Input)
				};
				inv_AdjustmentDetailsLst = dbExecutor.FetchData<inv_AdjustmentDetails>(CommandType.StoredProcedure, "inv_AdjustmentDetails_Get", colparameters);
				return inv_AdjustmentDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_AdjustmentDetails> GetAllAdjustmentDetailsFromAdjustmentId(String number)
		{
			try
			{
				List<inv_AdjustmentDetails> inv_AdjustmentDetailsLst = new List<inv_AdjustmentDetails>();
				Parameters[] colparameters = new Parameters[]{
				new Parameters("@AdjustmentNumber", number, DbType.String, ParameterDirection.Input)
				};
				inv_AdjustmentDetailsLst = dbExecutor.FetchData<inv_AdjustmentDetails>(CommandType.StoredProcedure, "inv_AdjustmentDetails_GetAll_From_AdjustmentId", colparameters);
				return inv_AdjustmentDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_AdjustmentDetails> GetDynamic(string whereCondition, string orderByExpression)
		{
			try
			{
				List<inv_AdjustmentDetails> inv_AdjustmentDetailsLst = new List<inv_AdjustmentDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_AdjustmentDetailsLst = dbExecutor.FetchData<inv_AdjustmentDetails>(CommandType.StoredProcedure, "inv_AdjustmentDetails_GetDynamic", colparameters);
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
		public int Post(inv_AdjustmentDetails _inv_AdjustmentDetails)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@Id", _inv_AdjustmentDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@AdjustmentNumber", _inv_AdjustmentDetails.AdjustmentNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@RackId", _inv_AdjustmentDetails.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ItemId", _inv_AdjustmentDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@IsIncreased", _inv_AdjustmentDetails.IsIncreased, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@AdjustedQty", _inv_AdjustmentDetails.AdjustedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@AdjstedUnitPrice", _inv_AdjustmentDetails.AdjstedUnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@Remarks", _inv_AdjustmentDetails.Remarks, DbType.String, ParameterDirection.Input)
				

				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "inv_AdjustmentDetails_Post", colparameters, true);
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
