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
	public class ad_PurposeDAO : IDisposable
	{
		private static volatile ad_PurposeDAO instance;
		private static readonly object lockObj = new object();
		public static ad_PurposeDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_PurposeDAO();
			}
			return instance;
		}
		public static ad_PurposeDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_PurposeDAO();
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

		public ad_PurposeDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_Purpose> Get(Int32? id = null)
		{
			try
			{
				List<ad_Purpose> ad_PurposeLst = new List<ad_Purpose>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramId", id, DbType.Int32, ParameterDirection.Input)
				};
				ad_PurposeLst = dbExecutor.FetchData<ad_Purpose>(CommandType.StoredProcedure, "wsp_ad_Purpose_Get", colparameters);
				return ad_PurposeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Purpose> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Purpose> ad_PurposeLst = new List<ad_Purpose>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_PurposeLst = dbExecutor.FetchData<ad_Purpose>(CommandType.StoredProcedure, "wsp_ad_Purpose_GetDynamic", colparameters);
				return ad_PurposeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Purpose> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Purpose> ad_PurposeLst = new List<ad_Purpose>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_PurposeLst = dbExecutor.FetchDataRef<ad_Purpose>(CommandType.StoredProcedure, "ad_Purpose_GetPaged", colparameters, ref rows);
				return ad_PurposeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_Purpose _ad_Purpose, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@paramId", _ad_Purpose.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramPurpose", _ad_Purpose.Purpose, DbType., ParameterDirection.Input),
				new Parameters("@paramIsActive", _ad_Purpose.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ad_Purpose.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _ad_Purpose.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ad_Purpose.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ad_Purpose.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_Purpose_Post", colparameters, true);
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
