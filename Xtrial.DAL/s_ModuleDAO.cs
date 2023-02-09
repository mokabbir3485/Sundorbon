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
	public class s_ModuleDAO : IDisposable
	{
		private static volatile s_ModuleDAO instance;
		private static readonly object lockObj = new object();
		public static s_ModuleDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new s_ModuleDAO();
			}
			return instance;
		}
		public static s_ModuleDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new s_ModuleDAO();
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

		public s_ModuleDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<s_Module> Get(Int32? moduleId = null)
		{
			try
			{
				List<s_Module> s_ModuleLst = new List<s_Module>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramModuleId", moduleId, DbType.Int32, ParameterDirection.Input)
				};
				s_ModuleLst = dbExecutor.FetchData<s_Module>(CommandType.StoredProcedure, "wsp_s_Module_Get", colparameters);
				return s_ModuleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<s_Module> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<s_Module> s_ModuleLst = new List<s_Module>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				s_ModuleLst = dbExecutor.FetchData<s_Module>(CommandType.StoredProcedure, "wsp_s_Module_GetDynamic", colparameters);
				return s_ModuleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<s_Module> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<s_Module> s_ModuleLst = new List<s_Module>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				s_ModuleLst = dbExecutor.FetchDataRef<s_Module>(CommandType.StoredProcedure, "s_Module_GetPaged", colparameters, ref rows);
				return s_ModuleLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(s_Module _s_Module, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[8]{
				new Parameters("@paramModuleId", _s_Module.ModuleId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDomainId", _s_Module.DomainId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramModuleName", _s_Module.ModuleName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _s_Module.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _s_Module.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _s_Module.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _s_Module.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_s_Module_Post", colparameters, true);
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
