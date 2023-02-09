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
	public class p_PurchaseBillDetailsDAO : IDisposable
	{
		private static volatile p_PurchaseBillDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static p_PurchaseBillDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new p_PurchaseBillDetailsDAO();
			}
			return instance;
		}
		public static p_PurchaseBillDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new p_PurchaseBillDetailsDAO();
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

		public p_PurchaseBillDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<p_PurchaseBillDetails> Get(Int32? id = null)
		{
			try
			{
				List<p_PurchaseBillDetails> p_PurchaseBillDetailsLst = new List<p_PurchaseBillDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				p_PurchaseBillDetailsLst = dbExecutor.FetchData<p_PurchaseBillDetails>(CommandType.StoredProcedure, "p_PurchaseBillDetails_Get", colparameters);
				return p_PurchaseBillDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<p_PurchaseBillDetails> GetByPurchaseBillNumber(string number)
		{
			try
			{
				List<p_PurchaseBillDetails> p_PurchaseBillDetailsLst = new List<p_PurchaseBillDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Number", number, DbType.String, ParameterDirection.Input)
				};
				p_PurchaseBillDetailsLst = dbExecutor.FetchData<p_PurchaseBillDetails>(CommandType.StoredProcedure, "p_PurchaseBillDetails_GetBy_Number", colparameters);
				return p_PurchaseBillDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<p_PurchaseBillDetails> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<p_PurchaseBillDetails> p_PurchaseBillDetailsLst = new List<p_PurchaseBillDetails>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				p_PurchaseBillDetailsLst = dbExecutor.FetchData<p_PurchaseBillDetails>(CommandType.StoredProcedure, "p_PurchaseBillDetails_GetDynamic", colparameters);
				return p_PurchaseBillDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<p_PurchaseBillDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<p_PurchaseBillDetails> p_PurchaseBillDetailsLst = new List<p_PurchaseBillDetails>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				p_PurchaseBillDetailsLst = dbExecutor.FetchDataRef<p_PurchaseBillDetails>(CommandType.StoredProcedure, "p_PurchaseBillDetails_GetPaged", colparameters, ref rows);
				return p_PurchaseBillDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(p_PurchaseBillDetails _p_PurchaseBillDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[12]{
				new Parameters("@Id", _p_PurchaseBillDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@PuchaseBillNumber", _p_PurchaseBillDetails.PuchaseBillNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ItemId", _p_PurchaseBillDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Qty", _p_PurchaseBillDetails.Qty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@UnitPrice", _p_PurchaseBillDetails.UnitPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@Amount", _p_PurchaseBillDetails.Amount, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@Discount", _p_PurchaseBillDetails.Discount, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@AfterDiscount", _p_PurchaseBillDetails.AfterDiscount, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@AIT", _p_PurchaseBillDetails.AIT, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@SD", _p_PurchaseBillDetails.SD, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@VAT", _p_PurchaseBillDetails.VAT, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@TransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "p_PurchaseBillDetails_Post", colparameters, true);
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
