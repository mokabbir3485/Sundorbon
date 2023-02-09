using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbExecutor;
using SecurityEntity;
using SecurityEntity.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class ad_EmployeeDAO
    {
        private static volatile ad_EmployeeDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public ad_EmployeeDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static ad_EmployeeDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new ad_EmployeeDAO();
                    }

                return instance;
            }
        }

        public static ad_EmployeeDAO GetInstance()
        {
            if (instance == null) instance = new ad_EmployeeDAO();
            return instance;
        }

        public int Add(ad_Employee _Employee)
        {
            var ret = 0;
            try
            {
                var colparameters = new Parameters[26]
                {
                     new Parameters("@EmployeeId", _Employee.EmployeeId, DbType.Int32,ParameterDirection.Input),
                     new Parameters("@DesignationId", _Employee.DesignationId, DbType.Int32,ParameterDirection.Input),
                     new Parameters("@Title", _Employee.Title, DbType.String,ParameterDirection.Input),
                     new Parameters("@FirstName", _Employee.FirstName, DbType.String,ParameterDirection.Input),
                     new Parameters("@MiddleName", _Employee.MiddleName, DbType.String,ParameterDirection.Input),
                     new Parameters("@LastName", _Employee.LastName, DbType.String,ParameterDirection.Input),
                     new Parameters("@EmployeeCode", _Employee.EmployeeCode, DbType.String,ParameterDirection.Input),
                     new Parameters("@ContactNo", _Employee.ContactNo, DbType.String, ParameterDirection.Input),
                     new Parameters("@Email", _Employee.Email, DbType.String, ParameterDirection.Input),
                     new Parameters("@Gender", _Employee.Gender, DbType.String, ParameterDirection.Input),
                     new Parameters("@PresentAddress", _Employee.PresentAddress, DbType.String, ParameterDirection.Input),
                     new Parameters("@DateOfBirth", _Employee.DateOfBirth, DbType.DateTime, ParameterDirection.Input),
                     
                     new Parameters("@IsUser", _Employee.IsUser, DbType.Boolean, ParameterDirection.Input),
                     new Parameters("@GradeId", _Employee.GradeId, DbType.Int32, ParameterDirection.Input),
                     new Parameters("@SectionId", _Employee.SectionId, DbType.Int32, ParameterDirection.Input),
                     new Parameters("@ManagerId", _Employee.ManagerId, DbType.Int32, ParameterDirection.Input),
                     new Parameters("@BloodGroup", _Employee.BloodGroup, DbType.String, ParameterDirection.Input),
                     new Parameters("@IsFlexibleOnDate", _Employee.IsFlexibleOnDate, DbType.Boolean, ParameterDirection.Input),
                     new Parameters("@IsFlexibleOnTime", _Employee.IsFlexibleOnTime, DbType.Boolean, ParameterDirection.Input),
                     new Parameters("@BasicSalary", _Employee.BasicSalary, DbType.Decimal, ParameterDirection.Input),
                     new Parameters("@JoiningDate", _Employee.JoiningDate, DbType.DateTime, ParameterDirection.Input),
                     new Parameters("@FinishDate", _Employee.FinishDate, DbType.DateTime, ParameterDirection.Input),

                     new Parameters("@IsActive", _Employee.IsActive, DbType.Boolean, ParameterDirection.Input),
                     new Parameters("@CreatorId", _Employee.CreatorId, DbType.Decimal, ParameterDirection.Input),
                     new Parameters("@UpdatorId", _Employee.UpdatorId, DbType.Decimal, ParameterDirection.Input),
                     new Parameters("@ContractTypeId", _Employee.ContractTypeId, DbType.Int32, ParameterDirection.Input),
                   
                };
                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Employee_Post",
                    colparameters, true);
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
        public List<ad_Employee> GetAll()
        {
            try
            {
                var ad_EmployeeLst = new List<ad_Employee>();
                ad_EmployeeLst =
                    dbExecutor.FetchData<ad_Employee>(CommandType.StoredProcedure, "ad_Employee_GetAll");
                return ad_EmployeeLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Employee> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                var ad_EmployeeLst = new List<ad_Employee>();
                var colparameters = new Parameters[2]
                {
                    new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
                    new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input)
                };
                ad_EmployeeLst = dbExecutor.FetchData<ad_Employee>(CommandType.StoredProcedure,
                    "ad_Employee_GetDynamic", colparameters);
                return ad_EmployeeLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Employee> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
           string sortOrder, ref int rows)
        {
            try
            {
                var ad_BankLst = new List<ad_Employee>();
                var colparameters = new Parameters[5]
                {
                    new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input)
                };
                ad_BankLst = dbExecutor.FetchDataRef<ad_Employee>(CommandType.StoredProcedure, "ad_Employee_GetPaged",
                    colparameters, ref rows);
                return ad_BankLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}