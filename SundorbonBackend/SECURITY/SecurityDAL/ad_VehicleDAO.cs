using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using DbExecutor;
using XtrialEntity;

namespace XtrialDAL
{
	public class ad_VehicleDAO : IDisposable
	{
		private static volatile ad_VehicleDAO instance;
		private static readonly object lockObj = new object();
		public static ad_VehicleDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_VehicleDAO();
			}
			return instance;
		}
		public static ad_VehicleDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_VehicleDAO();
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

		public ad_VehicleDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_Vehicle> Get(Int32? id = null)
		{
			try
			{
				List<ad_Vehicle> ad_VehicleLst = new List<ad_Vehicle>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_VehicleLst = dbExecutor.FetchData<ad_Vehicle>(CommandType.StoredProcedure, "ad_Vehicle_Get", colparameters);
				return ad_VehicleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Vehicle> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Vehicle> ad_VehicleLst = new List<ad_Vehicle>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_VehicleLst = dbExecutor.FetchData<ad_Vehicle>(CommandType.StoredProcedure, "ad_Vehicle_GetDynamic", colparameters);
				return ad_VehicleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Vehicle> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Vehicle> ad_VehicleLst = new List<ad_Vehicle>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_VehicleLst = dbExecutor.FetchDataRef<ad_Vehicle>(CommandType.StoredProcedure, "ad_Vehicle_GetPaged", colparameters, ref rows);
				return ad_VehicleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_Vehicle _ad_Vehicle)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[11]{
				new Parameters("@Id", _ad_Vehicle.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@VehicleNo", _ad_Vehicle.VehicleNo, DbType.String, ParameterDirection.Input),
				new Parameters("@EngineNo", _ad_Vehicle.EngineNo, DbType.String, ParameterDirection.Input),
				new Parameters("@ChasisNo", _ad_Vehicle.ChasisNo, DbType.String, ParameterDirection.Input),
				new Parameters("@ModelId", _ad_Vehicle.ModelId, DbType.String, ParameterDirection.Input),
				new Parameters("@IsOwnership", _ad_Vehicle.IsOwnership, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@EmployeeId", _ad_Vehicle.EmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@VehicleGroupId", _ad_Vehicle.VehicleGroupId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_Vehicle.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_Vehicle.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@IsActive", _ad_Vehicle.IsActive, DbType.Int32, ParameterDirection.Input),
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Vehicle_Post", colparameters, true);
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
		public List<ad_Vehicle> GetAllActive()
		{
			try
			{
				List<ad_Vehicle> ad_VehicleLst = new List<ad_Vehicle>();

				ad_VehicleLst = dbExecutor.FetchData<ad_Vehicle>(CommandType.StoredProcedure, "ad_Vehicle_GetAll_Active");
				return ad_VehicleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
