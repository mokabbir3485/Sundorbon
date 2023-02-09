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
	public class ad_ItemGroupDAO : IDisposable
	{
		private static volatile ad_ItemGroupDAO instance;
		private static readonly object lockObj = new object();
		public static ad_ItemGroupDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_ItemGroupDAO();
			}
			return instance;
		}
		public static ad_ItemGroupDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_ItemGroupDAO();
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

		public ad_ItemGroupDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_ItemGroup> Get(Int32? id = null)
		{
			try
			{
				List<ad_ItemGroup> ad_ItemGroupLst = new List<ad_ItemGroup>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_ItemGroupLst = dbExecutor.FetchData<ad_ItemGroup>(CommandType.StoredProcedure, "wsp_ad_ItemGroup_Get", colparameters);
				return ad_ItemGroupLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_ItemGroup> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_ItemGroup> ad_ItemGroupLst = new List<ad_ItemGroup>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_ItemGroupLst = dbExecutor.FetchData<ad_ItemGroup>(CommandType.StoredProcedure, "wsp_ad_ItemGroup_GetDynamic", colparameters);
				return ad_ItemGroupLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_ItemGroup> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_ItemGroup> ad_ItemGroupLst = new List<ad_ItemGroup>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_ItemGroupLst = dbExecutor.FetchDataRef<ad_ItemGroup>(CommandType.StoredProcedure, "ad_ItemGroup_GetPaged", colparameters, ref rows);
				return ad_ItemGroupLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_ItemGroup _ad_ItemGroup, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@paramId", _ad_ItemGroup.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramGroupName", _ad_ItemGroup.GroupName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramIsActive", _ad_ItemGroup.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ad_ItemGroup.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreationDate", _ad_ItemGroup.CreationDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ad_ItemGroup.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ad_ItemGroup.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_ItemGroup_Post", colparameters, true);
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
