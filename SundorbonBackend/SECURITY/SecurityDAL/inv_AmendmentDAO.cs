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
    public class inv_AmendmentDAO
    {
		private static volatile inv_AmendmentDAO instance;
		private static readonly object lockObj = new object();
		public static inv_AmendmentDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_AmendmentDAO();
			}
			return instance;
		}
		public static inv_AmendmentDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_AmendmentDAO();
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

		public inv_AmendmentDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_Ammendment> Get(Int32? id = null)
		{
			try
			{
				List<inv_Ammendment> inv_AmendmentLst = new List<inv_Ammendment>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				inv_AmendmentLst = dbExecutor.FetchData<inv_Ammendment>(CommandType.StoredProcedure, "inv_Amendment_Get", colparameters);
				return inv_AmendmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<inv_Ammendment> GetDynamic(string whereCondition, string orderByExpression)
		{
			try
			{
				List<inv_Ammendment> inv_AmendmentLst = new List<inv_Ammendment>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				inv_AmendmentLst = dbExecutor.FetchData<inv_Ammendment>(CommandType.StoredProcedure, "inv_Amendment_GetDynamic", colparameters);
				return inv_AmendmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_Ammendment> GetAll()
		{
			try
			{
				var ad_DepertmentLst = new List<inv_Ammendment>();
				ad_DepertmentLst =
					dbExecutor.FetchData<inv_Ammendment>(CommandType.StoredProcedure, "inv_Amendment_GetAll");
				return ad_DepertmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<inv_Ammendment> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<inv_Ammendment> inv_AmendmentLst = new List<inv_Ammendment>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				inv_AmendmentLst = dbExecutor.FetchDataRef<inv_Ammendment>(CommandType.StoredProcedure, "inv_Amendment_GetPaged", colparameters, ref rows);
				return inv_AmendmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int AddAmmendment(inv_Ammendment _Ammendment)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[6]{

				new Parameters("@Id", _Ammendment.Id, DbType.String, ParameterDirection.Input),
				new Parameters("@AmendDate", _Ammendment.AmendDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@ApprovalGivenOnId", _Ammendment.ApprovalGivenOnId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ReferenceTransactionNumber", _Ammendment.ReferenceTransactionNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@AmendmentByEmployeeId", _Ammendment.AmendmentByEmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@TransactionType", _Ammendment.TransactionType, DbType.String, ParameterDirection.Input),

				};

				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "inv_Amendment_Post", colparameters, true);
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
