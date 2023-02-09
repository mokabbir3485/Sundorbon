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
	public class ad_MotherCompanyDAO : IDisposable
	{
		private static volatile ad_MotherCompanyDAO instance;
		private static readonly object lockObj = new object();
		public static ad_MotherCompanyDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_MotherCompanyDAO();
			}
			return instance;
		}
		public static ad_MotherCompanyDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_MotherCompanyDAO();
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

		public ad_MotherCompanyDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_MotherCompany> Get(Int32? id = null)
		{
			try
			{
				List<ad_MotherCompany> ad_MotherCompanyLst = new List<ad_MotherCompany>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_MotherCompanyLst = dbExecutor.FetchData<ad_MotherCompany>(CommandType.StoredProcedure, "wsp_ad_MotherCompany_Get", colparameters);
				return ad_MotherCompanyLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_MotherCompany> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_MotherCompany> ad_MotherCompanyLst = new List<ad_MotherCompany>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_MotherCompanyLst = dbExecutor.FetchData<ad_MotherCompany>(CommandType.StoredProcedure, "wsp_ad_MotherCompany_GetDynamic", colparameters);
				return ad_MotherCompanyLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_MotherCompany> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_MotherCompany> ad_MotherCompanyLst = new List<ad_MotherCompany>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_MotherCompanyLst = dbExecutor.FetchDataRef<ad_MotherCompany>(CommandType.StoredProcedure, "ad_MotherCompany_GetPaged", colparameters, ref rows);
				return ad_MotherCompanyLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_MotherCompany _ad_MotherCompany, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@paramId", _ad_MotherCompany.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCompanyName", _ad_MotherCompany.CompanyName, DbType., ParameterDirection.Input),
				new Parameters("@paramBIN", _ad_MotherCompany.BIN, DbType., ParameterDirection.Input),
				new Parameters("@paramTIN", _ad_MotherCompany.TIN, DbType., ParameterDirection.Input),
				new Parameters("@paramVATRegNo", _ad_MotherCompany.VATRegNo, DbType., ParameterDirection.Input),
				new Parameters("@paramAddress1", _ad_MotherCompany.Address1, DbType., ParameterDirection.Input),
				new Parameters("@paramAddress2", _ad_MotherCompany.Address2, DbType., ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_MotherCompany_Post", colparameters, true);
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
