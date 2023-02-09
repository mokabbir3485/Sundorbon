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
    public class ad_CounterDAO
    {
		private static volatile ad_CounterDAO instance;
		private static readonly object lockObj = new object();
		public static ad_CounterDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_CounterDAO();
			}
			return instance;
		}
		public static ad_CounterDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_CounterDAO();
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

		public ad_CounterDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}
		public List<ad_Counter> GetAll()
		{
			try
			{
				var ad_MeasurementUnitLst = new List<ad_Counter>();
				ad_MeasurementUnitLst =
					dbExecutor.FetchData<ad_Counter>(CommandType.StoredProcedure, "ad_Counter_GetAll");
				return ad_MeasurementUnitLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Counter> GetAllNotUsedCounter(int DeptId)
		{
			try
			{
				var ad_MeasurementUnitLst = new List<ad_Counter>();
				var colparameters = new Parameters[1]
				{
					 new Parameters("@DeptId", DeptId, DbType.Int32,ParameterDirection.Input)
				};
				ad_MeasurementUnitLst =
					dbExecutor.FetchData<ad_Counter>(CommandType.StoredProcedure, "ad_Counter_GetAll_NotUsed", colparameters);
				return ad_MeasurementUnitLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int ChangeUsedStatus(int id,bool status)
		{
			var ret = 0;
			try
			{
				var colparameters = new Parameters[2]
				{
					 new Parameters("@Id", id, DbType.Int32,ParameterDirection.Input),
					 new Parameters("@IsUsed", status, DbType.Boolean,ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Counter_Update_Used_Status",
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
		public int Add(ad_Counter _counter)
		{
			var ret = 0;
			try
			{
				var colparameters = new Parameters[5]
				{
					 new Parameters("@Id", _counter.Id, DbType.Int32,
						ParameterDirection.Input),
					 new Parameters("@CounterName", _counter.CounterName, DbType.String,
						ParameterDirection.Input),
					 new Parameters("@DepartmentId", _counter.DepartmentId, DbType.Int32,
						ParameterDirection.Input),
					 new Parameters("@IPAddress", _counter.IPAddress, DbType.String,
						ParameterDirection.Input),
					 new Parameters("@ShortCode", _counter.ShortCode, DbType.String,
						ParameterDirection.Input)
					 

				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Counter_Post",
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
		public List<ad_Counter> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Counter> ad_VATLst = new List<ad_Counter>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_VATLst = dbExecutor.FetchDataRef<ad_Counter>(CommandType.StoredProcedure, "ad_Counter_GetPaged", colparameters, ref rows);
				return ad_VATLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
