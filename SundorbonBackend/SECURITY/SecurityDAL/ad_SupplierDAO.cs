using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using DbExecutor;
using XtrialEntity;
using Sundorbon.Backend.SECURITY.SecurityEntity;

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

		public List<ad_Get_Supplier> Get(Int32? id = null)
		{
			try
			{
				List<ad_Get_Supplier> ad_SupplierLst = new List<ad_Get_Supplier>();
			
				ad_SupplierLst = dbExecutor.FetchData<ad_Get_Supplier>(CommandType.StoredProcedure, "ad_Supplier_GetAll");
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
		public int Post(ad_Supplier _ad_Supplier)
		{
			var ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[12]{
				new Parameters("@Id", _ad_Supplier.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@SupplierName", _ad_Supplier.SupplierName, DbType.String, ParameterDirection.Input),
				new Parameters("@Address", _ad_Supplier.Address, DbType.String, ParameterDirection.Input),
				new Parameters("@Mobile", _ad_Supplier.Mobile, DbType.String, ParameterDirection.Input),
				new Parameters("@Email", _ad_Supplier.Email, DbType.String, ParameterDirection.Input),
				new Parameters("@BIN", _ad_Supplier.BIN, DbType.String, ParameterDirection.Input),
				new Parameters("@TIN", _ad_Supplier.TIN, DbType.String, ParameterDirection.Input),
				new Parameters("@VATRegNo", _ad_Supplier.VATRegNo, DbType.String, ParameterDirection.Input),
				new Parameters("@ContactPerson", _ad_Supplier.ContactPerson, DbType.String, ParameterDirection.Input),
				new Parameters("@IsActive", _ad_Supplier.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_Supplier.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_Supplier.UpdatorId, DbType.Int32, ParameterDirection.Input),
				//new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Supplier_Post", colparameters, true);
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
