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
   public class inv_StoreItemReceiveDAO
    {

		private static volatile inv_StoreItemReceiveDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StoreItemReceiveDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StoreItemReceiveDAO();
			}
			return instance;
		}
		public static inv_StoreItemReceiveDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StoreItemReceiveDAO();
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

		public inv_StoreItemReceiveDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}


		public List<inv_StoreItemReceive> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StoreItemReceive> ad_BranchLst = new List<inv_StoreItemReceive>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_BranchLst = dbExecutor.FetchDataRef<inv_StoreItemReceive>(CommandType.StoredProcedure, "inv_StoreItemReceive_GetPaged", colparameters, ref rows);
				return ad_BranchLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public string Post(inv_StoreItemReceive _inv_StoreItemReceive)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{
				new Parameters("@Number", _inv_StoreItemReceive.Number, DbType.String, ParameterDirection.Input),
				new Parameters("@StockReceiveDate", _inv_StoreItemReceive.StockReceiveDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@StockReceivedFrom", _inv_StoreItemReceive.StockReceivedFrom, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ReceivedByUserId", _inv_StoreItemReceive.ReceivedByUserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@PurchaseBillOrRequisitionSlipNo", _inv_StoreItemReceive.PurchaseBillOrRequisitionSlipNo, DbType.String, ParameterDirection.Input),
				new Parameters("@CounterId", _inv_StoreItemReceive.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Remarks", _inv_StoreItemReceive.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@UpdatorId", _inv_StoreItemReceive.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _inv_StoreItemReceive.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@TransactionType", _inv_StoreItemReceive.TransactionType, DbType.String, ParameterDirection.Input),
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "inv_StoreItemReceive_Post", colparameters, true);
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


		public int DetailPost(inv_StoreItemReceiveDetail _inv_StoreItemReceiveDetail)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[7]{
				new Parameters("@Id", _inv_StoreItemReceiveDetail.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@StoreReceiveNumber", _inv_StoreItemReceiveDetail.StoreReceiveNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@StockReceiveId", _inv_StoreItemReceiveDetail.StockReceiveId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@StoreRackId", _inv_StoreItemReceiveDetail.StoreRackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ItemId", _inv_StoreItemReceiveDetail.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ReceivedQty", _inv_StoreItemReceiveDetail.ReceivedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@ReceivedUnitPrice", _inv_StoreItemReceiveDetail.ReceivedUnitPrice, DbType.Decimal, ParameterDirection.Input),

				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "inv_StoreItemReceiveDetails_Post", colparameters, true);
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


		public List<inv_StoreItemReceiveDetail> StoreReciveDetails_GetBy_Number(string Number)
		{
			try
			{


				List<inv_StoreItemReceiveDetail> p_PurchaseBillDetailsList = new List<inv_StoreItemReceiveDetail>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

				};
				p_PurchaseBillDetailsList = dbExecutor.FetchData<inv_StoreItemReceiveDetail>(CommandType.StoredProcedure, "xrpt_StockReceiveDetail", colparameters);
				return p_PurchaseBillDetailsList;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
