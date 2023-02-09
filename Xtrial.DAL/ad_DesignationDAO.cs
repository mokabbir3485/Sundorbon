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
	public class ad_DesignationDAO : IDisposable
	{
		private static volatile ad_DesignationDAO instance;
		private static readonly object lockObj = new object();
		public static ad_DesignationDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_DesignationDAO();
			}
			return instance;
		}
		public static ad_DesignationDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_DesignationDAO();
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

		public ad_DesignationDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_Designation> Get(Int32? designationId = null)
		{
			try
			{
				List<ad_Designation> ad_DesignationLst = new List<ad_Designation>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramDesignationId", designationId, DbType.Int32, ParameterDirection.Input)
				};
				ad_DesignationLst = dbExecutor.FetchData<ad_Designation>(CommandType.StoredProcedure, "wsp_ad_Designation_Get", colparameters);
				return ad_DesignationLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Designation> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Designation> ad_DesignationLst = new List<ad_Designation>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_DesignationLst = dbExecutor.FetchData<ad_Designation>(CommandType.StoredProcedure, "wsp_ad_Designation_GetDynamic", colparameters);
				return ad_DesignationLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Designation> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Designation> ad_DesignationLst = new List<ad_Designation>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_DesignationLst = dbExecutor.FetchDataRef<ad_Designation>(CommandType.StoredProcedure, "ad_Designation_GetPaged", colparameters, ref rows);
				return ad_DesignationLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_Designation _ad_Designation, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[11]{
				new Parameters("@paramDesignationId", _ad_Designation.DesignationId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDepartmentId", _ad_Designation.DepartmentId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDesignationName", _ad_Designation.DesignationName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramContactNo", _ad_Designation.ContactNo, DbType.String, ParameterDirection.Input),
				new Parameters("@paramSerialNo", _ad_Designation.SerialNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramIsActive", _ad_Designation.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ad_Designation.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _ad_Designation.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ad_Designation.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ad_Designation.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_Designation_Post", colparameters, true);
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
