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
	public class ad_ItemDAO : IDisposable
	{
		private static volatile ad_ItemDAO instance;
		private static readonly object lockObj = new object();
		public static ad_ItemDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_ItemDAO();
			}
			return instance;
		}
		public static ad_ItemDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_ItemDAO();
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

		public ad_ItemDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_Item> Get(Int32? id = null)
		{
			try
			{
				List<ad_Item> ad_ItemLst = new List<ad_Item>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_ItemLst = dbExecutor.FetchData<ad_Item>(CommandType.StoredProcedure, "wsp_ad_Item_Get", colparameters);
				return ad_ItemLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Item> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Item> ad_ItemLst = new List<ad_Item>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_ItemLst = dbExecutor.FetchData<ad_Item>(CommandType.StoredProcedure, "wsp_ad_Item_GetDynamic", colparameters);
				return ad_ItemLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Item> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Item> ad_ItemLst = new List<ad_Item>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_ItemLst = dbExecutor.FetchDataRef<ad_Item>(CommandType.StoredProcedure, "ad_Item_GetPaged", colparameters, ref rows);
				return ad_ItemLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_Item _ad_Item, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[16]{
				new Parameters("@paramId", _ad_Item.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramItemCode", _ad_Item.ItemCode, DbType.String, ParameterDirection.Input),
				new Parameters("@paramProductName", _ad_Item.ProductName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramModelId", _ad_Item.ModelId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramItemGroupId", _ad_Item.ItemGroupId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramMeasureUnitId", _ad_Item.MeasureUnitId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramPurchaseVatId", _ad_Item.PurchaseVatId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramSupplimentaryDutyId", _ad_Item.SupplimentaryDutyId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramHasExpiry", _ad_Item.HasExpiry, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramROL", _ad_Item.ROL, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramIsActive", _ad_Item.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ad_Item.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _ad_Item.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ad_Item.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ad_Item.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_Item_Post", colparameters, true);
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
