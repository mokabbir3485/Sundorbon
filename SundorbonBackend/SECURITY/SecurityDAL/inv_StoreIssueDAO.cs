
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
  public class inv_StoreIssueDAO
    {
		private static volatile inv_StoreIssueDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StoreIssueDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StoreIssueDAO();
			}
			return instance;
		}
		public static inv_StoreIssueDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StoreIssueDAO();
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

		public inv_StoreIssueDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_StoreIssue> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_StoreIssue> ad_StoreLst = new List<inv_StoreIssue>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_StoreLst = dbExecutor.FetchDataRef<inv_StoreIssue>(CommandType.StoredProcedure, "inv_StoreIssue_GetPaged", colparameters, ref rows);
				return ad_StoreLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string AddStoreIssue(inv_StoreIssue _inv_StoreIssue)
		{
			string ret = "";
			try
			{
				Parameters[] colparameters = new Parameters[12]{
				new Parameters("@IssueNo", _inv_StoreIssue.IssueNo, DbType.String, ParameterDirection.Input),
				new Parameters("@IssueDate", _inv_StoreIssue.IssueDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@IssuedFromStoreId", _inv_StoreIssue.IssuedFromStoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@IssuedByUserId", _inv_StoreIssue.IssuedByUserId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@IssueTypeId", _inv_StoreIssue.IssueTypeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@PurposeId", _inv_StoreIssue.PurposeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ReferenceId", _inv_StoreIssue.ReferenceId, DbType.String, ParameterDirection.Input),
				new Parameters("@CounterId", _inv_StoreIssue.CounterId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ApprovalStatusId", _inv_StoreIssue.ApprovalStatusId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _inv_StoreIssue.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _inv_StoreIssue.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@TransactiontionType", _inv_StoreIssue.TransactiontionType, DbType.String, ParameterDirection.Input),
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "inv_StoreIssue_Post", colparameters, true);
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

		public int AddStoreIssueDetail(inv_StoreIssueDetail _inv_StoreIssueDetail)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[7]{
				new Parameters("@Id", _inv_StoreIssueDetail.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@IssueNumber", _inv_StoreIssueDetail.IssueNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@RackId", _inv_StoreIssueDetail.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ItemId", _inv_StoreIssueDetail.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@IssuedQty", _inv_StoreIssueDetail.IssuedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@IssuedPrice", _inv_StoreIssueDetail.IssuedPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@Remarks", _inv_StoreIssueDetail.Remarks, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "inv_StoreIssueDetails_Post", colparameters, true);
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


		public List<inv_StoreIssueDetail> xrpt_inv_StoreIssueDetails(string Number)
		{
			try
			{


				List<inv_StoreIssueDetail> p_PurchaseBillDetailsList = new List<inv_StoreIssueDetail>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", Number, DbType.String, ParameterDirection.Input),

				};
				p_PurchaseBillDetailsList = dbExecutor.FetchData<inv_StoreIssueDetail>(CommandType.StoredProcedure, "xrpt_inv_StoreIssueDetails", colparameters);
				return p_PurchaseBillDetailsList;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
