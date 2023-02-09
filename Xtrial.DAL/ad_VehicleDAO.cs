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
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_VehicleLst = dbExecutor.FetchData<ad_Vehicle>(CommandType.StoredProcedure, "wsp_ad_Vehicle_Get", colparameters);
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
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_VehicleLst = dbExecutor.FetchData<ad_Vehicle>(CommandType.StoredProcedure, "wsp_ad_Vehicle_GetDynamic", colparameters);
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
		public string Post(ad_Vehicle _ad_Vehicle, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[7]{
				new Parameters("@paramId", _ad_Vehicle.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramVehicleNo", _ad_Vehicle.VehicleNo, DbType., ParameterDirection.Input),
				new Parameters("@paramEngineNo", _ad_Vehicle.EngineNo, DbType., ParameterDirection.Input),
				new Parameters("@paramChasisNo", _ad_Vehicle.ChasisNo, DbType., ParameterDirection.Input),
				new Parameters("@paramModelId", _ad_Vehicle.ModelId, DbType., ParameterDirection.Input),
				new Parameters("@paramOwnershipId", _ad_Vehicle.OwnershipId, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_Vehicle_Post", colparameters, true);
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
