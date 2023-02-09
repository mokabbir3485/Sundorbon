using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using DbExecutor;
using Sundorbon.Backend.SECURITY.SecurityEntity;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
	public class ad_MeasurementUnitDAO : IDisposable
	{
		private static volatile ad_MeasurementUnitDAO instance;
		private static readonly object lockObj = new object();
		public static ad_MeasurementUnitDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_MeasurementUnitDAO();
			}
			return instance;
		}
		public static ad_MeasurementUnitDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_MeasurementUnitDAO();
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

		public ad_MeasurementUnitDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_MeasurementUnit> Get(Int32? id = null)
		{
			try
			{
				List<ad_MeasurementUnit> ad_MeasurementUnitLst = new List<ad_MeasurementUnit>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_MeasurementUnitLst = dbExecutor.FetchData<ad_MeasurementUnit>(CommandType.StoredProcedure, "ad_MeasurementUnit_Get", colparameters);
				return ad_MeasurementUnitLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_MeasurementUnit> GetAll()
		{
			try
			{
				var ad_MeasurementUnitLst = new List<ad_MeasurementUnit>();
				ad_MeasurementUnitLst =
					dbExecutor.FetchData<ad_MeasurementUnit>(CommandType.StoredProcedure, "ad_MeasurementUnit_GetAllActive");
				return ad_MeasurementUnitLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_MeasurementUnit> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_MeasurementUnit> ad_MeasurementUnitLst = new List<ad_MeasurementUnit>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_MeasurementUnitLst = dbExecutor.FetchData<ad_MeasurementUnit>(CommandType.StoredProcedure, "ad_MeasurementUnit_GetDynamic", colparameters);
				return ad_MeasurementUnitLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_MeasurementUnit> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_MeasurementUnit> ad_MeasurementUnitLst = new List<ad_MeasurementUnit>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_MeasurementUnitLst = dbExecutor.FetchDataRef<ad_MeasurementUnit>(CommandType.StoredProcedure, "ad_MeasurementUnit_GetPaged", colparameters, ref rows);
				return ad_MeasurementUnitLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Add(ad_MeasurementUnit _MeasurementUnit)
		{
			var ret = 0;
			try
			{
				var colparameters = new Parameters[5]
				{
					 new Parameters("@Id", _MeasurementUnit.Id, DbType.Int32,
						ParameterDirection.Input),
					new Parameters("@UnitDescription", _MeasurementUnit.UnitDescription, DbType.String,
						ParameterDirection.Input),
					new Parameters("@IsActive", _MeasurementUnit.IsActive, DbType.Boolean, ParameterDirection.Input),
					new Parameters("@CreatorId", _MeasurementUnit.CreatorId, DbType.Int32, ParameterDirection.Input),
					new Parameters("@UpdatorId", _MeasurementUnit.UpdatorId, DbType.Int32, ParameterDirection.Input),

				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_MeasurementUnit_Post",
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
	}
}
