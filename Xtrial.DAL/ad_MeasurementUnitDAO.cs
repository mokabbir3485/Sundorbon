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
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_MeasurementUnitLst = dbExecutor.FetchData<ad_MeasurementUnit>(CommandType.StoredProcedure, "wsp_ad_MeasurementUnit_Get", colparameters);
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
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_MeasurementUnitLst = dbExecutor.FetchData<ad_MeasurementUnit>(CommandType.StoredProcedure, "wsp_ad_MeasurementUnit_GetDynamic", colparameters);
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
		public string Post(ad_MeasurementUnit _ad_MeasurementUnit, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@paramId", _ad_MeasurementUnit.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUnitDescription", _ad_MeasurementUnit.UnitDescription, DbType.String, ParameterDirection.Input),
				new Parameters("@paramIsActive", _ad_MeasurementUnit.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ad_MeasurementUnit.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _ad_MeasurementUnit.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ad_MeasurementUnit.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ad_MeasurementUnit.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_MeasurementUnit_Post", colparameters, true);
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
