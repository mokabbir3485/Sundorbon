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
	public class ad_VATDAO : IDisposable
	{
		private static volatile ad_VATDAO instance;
		private static readonly object lockObj = new object();
		public static ad_VATDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_VATDAO();
			}
			return instance;
		}
		public static ad_VATDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_VATDAO();
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

		public ad_VATDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		//public List<ad_VAT> Get(Int32? id = null)
		//{
		//	try
		//	{
		//		List<ad_VAT> ad_VATLst = new List<ad_VAT>();
		//		Parameters[] colparameters = new Parameters[1]{
		//		new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
		//		};
		//		ad_VATLst = dbExecutor.FetchData<ad_VAT>(CommandType.StoredProcedure, "ad_VAT_GetAll", colparameters);
		//		return ad_VATLst;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}
		public List<ad_VAT> GetAll()
		{
			try
			{
				var ad_VATLst = new List<ad_VAT>();
				ad_VATLst =
					dbExecutor.FetchData<ad_VAT>(CommandType.StoredProcedure, "ad_VAT_GetAll");
				return ad_VATLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_VAT> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_VAT> ad_VATLst = new List<ad_VAT>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_VATLst = dbExecutor.FetchData<ad_VAT>(CommandType.StoredProcedure, "ad_VAT_GetDynamic", colparameters);
				return ad_VATLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_VAT> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_VAT> ad_VATLst = new List<ad_VAT>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_VATLst = dbExecutor.FetchDataRef<ad_VAT>(CommandType.StoredProcedure, "ad_VAT_GetPaged", colparameters, ref rows);
				return ad_VATLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Post(ad_VAT _ad_VAT)
		{
			int ret = 0;
			try
			{
				Parameters[] colparameters = new Parameters[6]{
				new Parameters("@Id", _ad_VAT.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@VatPercent", _ad_VAT.VatPercent, DbType.String, ParameterDirection.Input),
				new Parameters("@PercentNumber", _ad_VAT.PercentNumber, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@IsActive", _ad_VAT.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@CreatorId", _ad_VAT.CreatorId, DbType.Int32, ParameterDirection.Input),
				//new Parameters("@paramCreationDate", _ad_VAT.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@UpdatorId", _ad_VAT.UpdatorId, DbType.Int32, ParameterDirection.Input),
				//new Parameters("@paramUpdateDate", _ad_VAT.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				//new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_VAT_Post", colparameters, true);
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
