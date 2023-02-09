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
	public class ad_SupplierDAO : IDisposable
	{
		private static volatile ad_SupplierDAO instance;
		private static readonly object lockObj = new object();
		public static ad_SupplierDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_SupplierDAO();
			}
			return instance;
		}
		public static ad_SupplierDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_SupplierDAO();
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

		public ad_SupplierDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_Supplier> Get(Int32? id = null)
		{
			try
			{
				List<ad_Supplier> ad_SupplierLst = new List<ad_Supplier>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_SupplierLst = dbExecutor.FetchData<ad_Supplier>(CommandType.StoredProcedure, "wsp_ad_Supplier_Get", colparameters);
				return ad_SupplierLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Supplier> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Supplier> ad_SupplierLst = new List<ad_Supplier>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_SupplierLst = dbExecutor.FetchData<ad_Supplier>(CommandType.StoredProcedure, "wsp_ad_Supplier_GetDynamic", colparameters);
				return ad_SupplierLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Supplier> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Supplier> ad_SupplierLst = new List<ad_Supplier>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_SupplierLst = dbExecutor.FetchDataRef<ad_Supplier>(CommandType.StoredProcedure, "ad_Supplier_GetPaged", colparameters, ref rows);
				return ad_SupplierLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_Supplier _ad_Supplier, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[15]{
				new Parameters("@paramId", _ad_Supplier.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramSupplierName", _ad_Supplier.SupplierName, DbType., ParameterDirection.Input),
				new Parameters("@paramAddress", _ad_Supplier.Address, DbType., ParameterDirection.Input),
				new Parameters("@paramMobile", _ad_Supplier.Mobile, DbType., ParameterDirection.Input),
				new Parameters("@paramEmail", _ad_Supplier.Email, DbType., ParameterDirection.Input),
				new Parameters("@paramBIN", _ad_Supplier.BIN, DbType., ParameterDirection.Input),
				new Parameters("@paramTIN", _ad_Supplier.TIN, DbType., ParameterDirection.Input),
				new Parameters("@paramVATRegNo", _ad_Supplier.VATRegNo, DbType., ParameterDirection.Input),
				new Parameters("@paramContactPerson", _ad_Supplier.ContactPerson, DbType., ParameterDirection.Input),
				new Parameters("@paramIsActive", _ad_Supplier.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ad_Supplier.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _ad_Supplier.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ad_Supplier.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ad_Supplier.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_Supplier_Post", colparameters, true);
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
