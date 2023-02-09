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
    public class ws_JobItemDetailsDAO
    {
		private static volatile ws_JobItemDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static ws_JobItemDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_JobItemDetailsDAO();
			}
			return instance;
		}
		public static ws_JobItemDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_JobItemDetailsDAO();
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

		public ws_JobItemDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

        public List<ws_JobItemDetails> GetByJobNumber(string Number)
        {
            try
            {
                List<ws_JobItemDetails> ws_JobItemDetailsLst = new List<ws_JobItemDetails>();
				Parameters[] colparameters = new Parameters[1]{
					new Parameters("@Number", Number, DbType.String, ParameterDirection.Input)
				};
				ws_JobItemDetailsLst = dbExecutor.FetchData<ws_JobItemDetails>(CommandType.StoredProcedure, "ws_JobItemDetails_GetAll_By_JobNumber", colparameters);
                return ws_JobItemDetailsLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ws_JobItemDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ws_JobItemDetails> ws_JobItemDetailsLst = new List<ws_JobItemDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ws_JobItemDetailsLst = dbExecutor.FetchDataRef<ws_JobItemDetails>(CommandType.StoredProcedure, "ws_JobItemDetails_GetPaged", colparameters, ref rows);
				return ws_JobItemDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Post(ws_JobItemDetails _ws_JobItemDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[9]{

				new Parameters("@Id", _ws_JobItemDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@JobNumber", _ws_JobItemDetails.JobNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ItemId", _ws_JobItemDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ItemRequiredFromStoreQty", _ws_JobItemDetails.ItemRequiredFromStoreQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@ItemReusableQty", _ws_JobItemDetails.ItemReusableQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@ItemDamagedQty", _ws_JobItemDetails.ItemDamagedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@IsVoid", _ws_JobItemDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@Remarks", _ws_JobItemDetails.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@TransactiontionType", transactionType, DbType.String, ParameterDirection.Input),

				};

				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "ws_JobItemDetails_Post", colparameters, true);
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
