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
	public class ad_EmployeeDAO : IDisposable
	{
		private static volatile ad_EmployeeDAO instance;
		private static readonly object lockObj = new object();
		public static ad_EmployeeDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ad_EmployeeDAO();
			}
			return instance;
		}
		public static ad_EmployeeDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ad_EmployeeDAO();
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

		public ad_EmployeeDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ad_Employee> Get(Int32? employeeId = null)
		{
			try
			{
				List<ad_Employee> ad_EmployeeLst = new List<ad_Employee>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@paramEmployeeId", employeeId, DbType.Int32, ParameterDirection.Input)
				};
				ad_EmployeeLst = dbExecutor.FetchData<ad_Employee>(CommandType.StoredProcedure, "wsp_ad_Employee_Get", colparameters);
				return ad_EmployeeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ad_Employee> GetDynamic(string whereCondition,string orderByExpression)
		{
			try
			{
				List<ad_Employee> ad_EmployeeLst = new List<ad_Employee>();
				Parameters[] colparameters = new Parameters[2]{
				new Parameters("@paramWhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
				new Parameters("@paramOrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
				};
				ad_EmployeeLst = dbExecutor.FetchData<ad_Employee>(CommandType.StoredProcedure, "wsp_ad_Employee_GetDynamic", colparameters);
				return ad_EmployeeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ad_Employee> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		{
			try
			{
				List<ad_Employee> ad_EmployeeLst = new List<ad_Employee>();
				Parameters[] colparameters = new Parameters[5]{
				new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
				new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
				new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
				new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
				};
				ad_EmployeeLst = dbExecutor.FetchDataRef<ad_Employee>(CommandType.StoredProcedure, "ad_Employee_GetPaged", colparameters, ref rows);
				return ad_EmployeeLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string Post(ad_Employee _ad_Employee, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[30]{
				new Parameters("@paramEmployeeId", _ad_Employee.EmployeeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDepartmentId", _ad_Employee.DepartmentId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramDesignationId", _ad_Employee.DesignationId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramTitle", _ad_Employee.Title, DbType.String, ParameterDirection.Input),
				new Parameters("@paramFirstName", _ad_Employee.FirstName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramMiddleName", _ad_Employee.MiddleName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramLastName", _ad_Employee.LastName, DbType.String, ParameterDirection.Input),
				new Parameters("@paramEmployeeCode", _ad_Employee.EmployeeCode, DbType.String, ParameterDirection.Input),
				new Parameters("@paramContactNo", _ad_Employee.ContactNo, DbType.String, ParameterDirection.Input),
				new Parameters("@paramEmail", _ad_Employee.Email, DbType.String, ParameterDirection.Input),
				new Parameters("@paramGender", _ad_Employee.Gender, DbType.String, ParameterDirection.Input),
				new Parameters("@paramPresentAddress", _ad_Employee.PresentAddress, DbType.String, ParameterDirection.Input),
				new Parameters("@paramDateOfBirth", _ad_Employee.DateOfBirth, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramIsUser", _ad_Employee.IsUser, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramGradeId", _ad_Employee.GradeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramSectionId", _ad_Employee.SectionId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramManagerId", _ad_Employee.ManagerId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramBloodGroup", _ad_Employee.BloodGroup, DbType.String, ParameterDirection.Input),
				new Parameters("@paramIsFlexibleOnDate", _ad_Employee.IsFlexibleOnDate, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramIsFlexibleOnTime", _ad_Employee.IsFlexibleOnTime, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramBasicSalary", _ad_Employee.BasicSalary, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@paramJoiningDate", _ad_Employee.JoiningDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramFinishDate", _ad_Employee.FinishDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramIsActive", _ad_Employee.IsActive, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@paramCreatorId", _ad_Employee.CreatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramCreateDate", _ad_Employee.CreateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramUpdatorId", _ad_Employee.UpdatorId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramUpdateDate", _ad_Employee.UpdateDate, DbType.DateTime, ParameterDirection.Input),
				new Parameters("@paramContractTypeId", _ad_Employee.ContractTypeId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@paramTransactionType", transactionType, DbType.String, ParameterDirection.Input)
				};
				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "wsp_ad_Employee_Post", colparameters, true);
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
