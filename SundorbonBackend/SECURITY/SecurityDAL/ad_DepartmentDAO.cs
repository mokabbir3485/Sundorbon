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
    public class ad_DepartmentDAO
    {
		private static volatile ad_DepartmentDAO instance;
		private static readonly object lockObj = new object();
		public static ad_DepartmentDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_DepartmentDAO();
			}
			return instance;
		}
		public static ad_DepartmentDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_DepartmentDAO();
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

		public ad_DepartmentDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}
		public List<ad_Depertment> GetAll()
		{
			try
			{
				var ad_DepertmentLst = new List<ad_Depertment>();
				ad_DepertmentLst =
					dbExecutor.FetchData<ad_Depertment>(CommandType.StoredProcedure, "ad_Department_GetAll");
				return ad_DepertmentLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Add(ad_Depertment _Depertment)
		{
			var ret = 0;
			try
			{
				var colparameters = new Parameters[5]
				{
					 new Parameters("@Id", _Depertment.Id, DbType.Int32,
						ParameterDirection.Input),
					 new Parameters("@BranchId", _Depertment.BranchId, DbType.Int32,
						ParameterDirection.Input),
					 new Parameters("@DepartmentName", _Depertment.DepartmentName, DbType.String,
						ParameterDirection.Input),
					 new Parameters("@Address1", _Depertment.Address1, DbType.String,
						ParameterDirection.Input),
					 new Parameters("@Address2", _Depertment.Address2, DbType.String,
						ParameterDirection.Input)


				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Department_Post",
					colparameters, true);
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
		public List<ad_Depertment> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Depertment> ad_DeptLst = new List<ad_Depertment>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_DeptLst = dbExecutor.FetchDataRef<ad_Depertment>(CommandType.StoredProcedure, "ad_Department_GetPaged", colparameters, ref rows);
				return ad_DeptLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
