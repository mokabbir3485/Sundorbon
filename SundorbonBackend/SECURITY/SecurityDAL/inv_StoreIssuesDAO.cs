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
    public class inv_StoreIssuesDAO
    {
		private static volatile inv_StoreIssuesDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StoreIssuesDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StoreIssuesDAO();
			}
			return instance;
		}
		public static inv_StoreIssuesDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StoreIssuesDAO();
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

		public inv_StoreIssuesDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}


		public List<inv_StoreIssue> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StoreIssue> ad_BranchLst = new List<inv_StoreIssue>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_BranchLst = dbExecutor.FetchDataRef<inv_StoreIssue>(CommandType.StoredProcedure, "inv_StoreIssues_GetPaged", colparameters, ref rows);
				return ad_BranchLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_StoreIssue> GetAll()
        {
			try
			{
				List<inv_StoreIssue> ad_BranchLst = new List<inv_StoreIssue>();
				
				ad_BranchLst = dbExecutor.FetchData<inv_StoreIssue>(CommandType.StoredProcedure, "ws_Get_StoareIssue_Number");
				return ad_BranchLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		//public string Post(inv_StoreIssue _inv_StoreIssues)
		//{
		//	string ret = string.Empty;
		//	try
		//	{
		//		Parameters[] colparameters = new Parameters[10]{
		//		new Parameters("@Number", _inv_StoreIssues.Number, DbType.String, ParameterDirection.Input),
		//		new Parameters("@StockReceiveDate", _inv_StoreIssues.StockReceiveDate, DbType.DateTime, ParameterDirection.Input),
		//		new Parameters("@StockReceivedFrom", _inv_StoreIssues.StockReceivedFrom, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@ReceivedByUserId", _inv_StoreIssues.ReceivedByUserId, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@PurchaseBillOrRequisitionSlipNo", _inv_StoreIssues.PurchaseBillOrRequisitionSlipNo, DbType.String, ParameterDirection.Input),
		//		new Parameters("@CounterId", _inv_StoreIssues.CounterId, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@Remarks", _inv_StoreIssues.Remarks, DbType.String, ParameterDirection.Input),
		//		new Parameters("@UpdatorId", _inv_StoreIssues.UpdatorId, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@CreatorId", _inv_StoreIssues.CreatorId, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@TransactionType", _inv_StoreIssues.TransactionType, DbType.String, ParameterDirection.Input),
		//		};
		//		dbExecutor.ManageTransaction(TransactionType.Open);
		//		ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "inv_StoreIssues_Post", colparameters, true);
		//		dbExecutor.ManageTransaction(TransactionType.Commit);
		//	}
		//	catch (DBConcurrencyException except)
		//	{
		//		dbExecutor.ManageTransaction(TransactionType.Rollback);
		//		throw except;
		//	}
		//	catch (Exception ex)
		//	{
		//		dbExecutor.ManageTransaction(TransactionType.Rollback);
		//		throw ex;
		//	}
		//	return ret;
		//}


		//public int DetailPost(inv_StoreIssueDetails _inv_StoreIssuesDetail)
		//{
		//	int ret = 0;
		//	try
		//	{
		//		Parameters[] colparameters = new Parameters[7]{
		//		new Parameters("@Id", _inv_StoreIssuesDetail.Id, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@StoreReceiveNumber", _inv_StoreIssuesDetail.StoreReceiveNumber, DbType.String, ParameterDirection.Input),
		//		new Parameters("@StockReceiveId", _inv_StoreIssuesDetail.StockReceiveId, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@StoreRackId", _inv_StoreIssuesDetail.StoreRackId, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@ItemId", _inv_StoreIssuesDetail.ItemId, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@ReceivedQty", _inv_StoreIssuesDetail.ReceivedQty, DbType.Decimal, ParameterDirection.Input),
		//		new Parameters("@ReceivedUnitPrice", _inv_StoreIssuesDetail.ReceivedUnitPrice, DbType.Decimal, ParameterDirection.Input),

		//		};
		//		dbExecutor.ManageTransaction(TransactionType.Open);
		//		ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "inv_StoreIssuesDetails_Post", colparameters, true);
		//		dbExecutor.ManageTransaction(TransactionType.Commit);
		//	}
		//	catch (DBConcurrencyException except)
		//	{
		//		dbExecutor.ManageTransaction(TransactionType.Rollback);
		//		throw except;
		//	}
		//	catch (Exception ex)
		//	{
		//		dbExecutor.ManageTransaction(TransactionType.Rollback);
		//		throw ex;
		//	}
		//	return ret;
		//}


		//public List<inv_StoreIssueDetails> StoreReciveDetails_GetBy_Number(string Number)
		//{
		//	try
		//	{


		//		List<inv_StoreIssueDetails> p_PurchaseBillDetailsList = new List<inv_StoreIssueDetails>();
		//		Parameters[] colparameters = new Parameters[1]{
		//		new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

		//		};
		//		p_PurchaseBillDetailsList = dbExecutor.FetchData<inv_StoreIssueDetails>(CommandType.StoredProcedure, "xrpt_StockReceiveDetail", colparameters);
		//		return p_PurchaseBillDetailsList;

		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}

	}
}
